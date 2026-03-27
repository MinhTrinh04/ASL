using UnityEngine;
using System.Collections.Generic;

public class GestureTopicController : MonoBehaviour
{
    [System.Serializable]
    public struct TopicGroup
    {
        public string topicName;
        public GameObject gestureGroupObject;
    }

    public List<TopicGroup> topics = new List<TopicGroup>();

    public void EnableTopic(string topicName)
    {
        foreach (var topic in topics)
        {
            if (topic.gestureGroupObject != null)
            {
                bool isActive = topic.topicName.Equals(topicName, System.StringComparison.OrdinalIgnoreCase);
                topic.gestureGroupObject.SetActive(isActive);
            }
        }
        Debug.Log($"[GestureTopicController] Switched to topic: {topicName}");
    }
}