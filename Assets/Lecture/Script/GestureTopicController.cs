using UnityEngine;
using System.Collections.Generic;

public class GestureTopicController : MonoBehaviour
{
    [System.Serializable]
    public struct TopicGroup
    {
        public string topicName;
        public GameObject gestureGroupObject;
        public Transform topicSpawnPoint;
    }

    public List<TopicGroup> topics = new List<TopicGroup>();

    public void EnableTopicByIndex(int index)
    {
        for (int i = 0; i < topics.Count; i++)
        {
            if (topics[i].gestureGroupObject != null)
            {
                topics[i].gestureGroupObject.SetActive(i == index);
            }
        }
        
        if (index >= 0 && index < topics.Count)
            Debug.Log($"[GestureTopicController] Switched to topic: {topics[index].topicName} (Index: {index})");
    }

    public Transform GetSpawnPointByIndex(int index)
    {
        if (index >= 0 && index < topics.Count)
        {
            return topics[index].topicSpawnPoint;
        }
        return null;
    }

    // Keep legacy method for backward compatibility if needed, but updated to internal index search
    public void EnableTopic(string topicName)
    {
        for (int i = 0; i < topics.Count; i++)
        {
            if (topics[i].topicName.Equals(topicName, System.StringComparison.OrdinalIgnoreCase))
            {
                EnableTopicByIndex(i);
                return;
            }
        }
    }
}