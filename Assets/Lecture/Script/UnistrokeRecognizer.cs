using System;
using System.Collections.Generic;
using UnityEngine;

public class VRMagicUnistroke
{
    public const int NumPoints = 64;
    public const float SquareSize = 250.0f;
    public const float HalfDiagonal = 176.776695f; // sqrt(250^2 + 250^2) / 2
    public const float AngleRange = 45.0f * Mathf.Deg2Rad;
    public const float AnglePrecision = 2.0f * Mathf.Deg2Rad;
    public const float Phi = 0.6180339f; // Golden Ratio

    public struct Point
    {
        public float X, Y;
        public Point(float x, float y) { X = x; Y = y; }
    }

    public class Template
    {
        public string Name;
        public List<Point> Points;

        public Template(string name, List<Point> points)
        {
            Name = name;
            Points = Resample(points, NumPoints);
            float radians = IndicativeAngle(Points);
            Points = RotateBy(Points, -radians);
            Points = ScaleTo(Points, SquareSize);
            Points = TranslateTo(Points, new Point(0, 0));
        }
    }

    public static List<Point> Normalize(List<Point> points)
    {
        var p = Resample(points, NumPoints);
        float radians = IndicativeAngle(p);
        p = RotateBy(p, -radians);
        p = ScaleTo(p, SquareSize);
        p = TranslateTo(p, new Point(0, 0));
        return p;
    }

    public static float Recognize(List<Point> points, Template template)
    {
        if (points == null || points.Count < 2) return 0f;
        var normalized = Normalize(points);
        float d = DistanceAtBestAngle(normalized, template, -AngleRange, AngleRange, AnglePrecision);
        float score = 1.0f - (d / HalfDiagonal);
        return Mathf.Clamp01(score);
    }

    // --- Math functions ---
    private static List<Point> Resample(List<Point> points, int n)
    {
        float I = PathLength(points) / (n - 1);
        float D = 0.0f;
        var newPoints = new List<Point>() { points[0] };
        for (int i = 1; i < points.Count; i++)
        {
            float d = Distance(points[i - 1], points[i]);
            if ((D + d) >= I)
            {
                float qx = points[i - 1].X + ((I - D) / d) * (points[i].X - points[i - 1].X);
                float qy = points[i - 1].Y + ((I - D) / d) * (points[i].Y - points[i - 1].Y);
                Point q = new Point(qx, qy);
                newPoints.Add(q);
                points.Insert(i, q); 
                D = 0.0f;
            }
            else D += d;
        }
        if (newPoints.Count == n - 1) newPoints.Add(new Point(points[points.Count - 1].X, points[points.Count - 1].Y)); 
        return newPoints;
    }

    private static float IndicativeAngle(List<Point> points)
    {
        Point c = Centroid(points);
        return Mathf.Atan2(c.Y - points[0].Y, c.X - points[0].X);
    }

    private static List<Point> RotateBy(List<Point> points, float radians)
    {
        Point c = Centroid(points);
        float cos = Mathf.Cos(radians);
        float sin = Mathf.Sin(radians);
        var newPoints = new List<Point>();
        foreach (var p in points)
        {
            float qx = (p.X - c.X) * cos - (p.Y - c.Y) * sin + c.X;
            float qy = (p.X - c.X) * sin + (p.Y - c.Y) * cos + c.Y;
            newPoints.Add(new Point(qx, qy));
        }
        return newPoints;
    }

    private static List<Point> ScaleTo(List<Point> points, float size)
    {
        var bb = BoundingBox(points);
        var newPoints = new List<Point>();
        foreach (var p in points)
        {
            float qx = p.X * (size / bb.width);
            float qy = p.Y * (size / bb.height);
            newPoints.Add(new Point(qx, qy));
        }
        return newPoints;
    }

    private static List<Point> TranslateTo(List<Point> points, Point pt)
    {
        Point c = Centroid(points);
        var newPoints = new List<Point>();
        foreach (var p in points)
        {
            float qx = p.X + pt.X - c.X;
            float qy = p.Y + pt.Y - c.Y;
            newPoints.Add(new Point(qx, qy));
        }
        return newPoints;
    }

    private static float DistanceAtBestAngle(List<Point> points, Template T, float a, float b, float threshold)
    {
        float x1 = Phi * a + (1.0f - Phi) * b;
        float f1 = DistanceAtAngle(points, T, x1);
        float x2 = (1.0f - Phi) * a + Phi * b;
        float f2 = DistanceAtAngle(points, T, x2);

        while (Mathf.Abs(b - a) > threshold)
        {
            if (f1 < f2)
            {
                b = x2;
                x2 = x1;
                f2 = f1;
                x1 = Phi * a + (1.0f - Phi) * b;
                f1 = DistanceAtAngle(points, T, x1);
            }
            else
            {
                a = x1;
                x1 = x2;
                f1 = f2;
                x2 = (1.0f - Phi) * a + Phi * b;
                f2 = DistanceAtAngle(points, T, x2);
            }
        }
        return Mathf.Min(f1, f2);
    }

    private static float DistanceAtAngle(List<Point> points, Template T, float radians)
    {
        var newPoints = RotateBy(points, radians);
        return PathDistance(newPoints, T.Points);
    }

    private static float PathDistance(List<Point> pts1, List<Point> pts2)
    {
        float d = 0.0f;
        for (int i = 0; i < pts1.Count && i < pts2.Count; i++) 
            d += Distance(pts1[i], pts2[i]);
        return d / pts1.Count;
    }

    private static float PathLength(List<Point> points)
    {
        float d = 0.0f;
        for (int i = 1; i < points.Count; i++)
            d += Distance(points[i - 1], points[i]);
        return d;
    }

    private static float Distance(Point p1, Point p2)
    {
        float dx = p2.X - p1.X;
        float dy = p2.Y - p1.Y;
        return Mathf.Sqrt(dx * dx + dy * dy);
    }

    private static Point Centroid(List<Point> points)
    {
        float x = 0.0f, y = 0.0f;
        foreach (var p in points) { x += p.X; y += p.Y; }
        x /= points.Count;
        y /= points.Count;
        return new Point(x, y);
    }

    private static Rect BoundingBox(List<Point> points)
    {
        float minX = float.MaxValue, maxX = float.MinValue, minY = float.MaxValue, maxY = float.MinValue;
        foreach (var p in points)
        {
            if (p.X < minX) minX = p.X;
            if (p.X > maxX) maxX = p.X;
            if (p.Y < minY) minY = p.Y;
            if (p.Y > maxY) maxY = p.Y;
        }
        return new Rect(minX, minY, Mathf.Max(0.01f, maxX - minX), Mathf.Max(0.01f, maxY - minY));
    }
}
