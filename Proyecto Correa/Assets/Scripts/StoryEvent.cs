using UnityEngine;
using UnityEngine.Events;

public class StoryEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _storyEvent;

    public void OnStoryEvent()
    {
        _storyEvent.Invoke();
    }
}
