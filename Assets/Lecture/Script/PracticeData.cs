using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewPractice", menuName = "Lecture/Practice Data")]
public class PracticeData : ScriptableObject
{
    public string targetWord; // "CLASS" hoặc "ASL"
    public List<string> gestureSequence; // VD: ["C", "L", "A", "S", "S"]
}