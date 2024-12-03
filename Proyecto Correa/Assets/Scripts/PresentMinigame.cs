using UnityEngine;

public class PresentMinigame : MonoBehaviour
{
    [SerializeField] private MouseActivator _mouseActivator;

    private NarrativeManager _narrative;
    private Rigidbody[] _layers;
    private Drag3D _drag;
    private StoryEvent _event;
    
    [SerializeField] private double _maxTravel;
    private int _level;
    private bool _levelCompleted = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _narrative = NarrativeManager.Instance;
        _mouseActivator.ChangeMouseState();
        _drag = GetComponent<Drag3D>();
        _event = GetComponent<StoryEvent>();
        
        _layers = new Rigidbody[transform.childCount - 1];
        for (int i = 0; i < _layers.Length; i++)
        {
            _layers[i] = transform.GetChild(i + 1).gameObject.GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_drag.Traveled >= _maxTravel)
        {
            for (int i = _level; i < _level + 10; i++)
            {
                _layers[i].useGravity = true;
            }
            _level += 10;
            _drag.ResetTraveledDistance();

            if (_level == 30 && !_levelCompleted)
            {
                _mouseActivator.ChangeMouseState();
                Debug.Log("LevelState" + _levelCompleted);
                _levelCompleted = true;
                _narrative.EventByName("MinigameEnded", "Acto" + _narrative.Act);
            }
        }
    }
}
