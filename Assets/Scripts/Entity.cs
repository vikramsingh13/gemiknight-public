using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private string _name = string.Empty;
    private EventManager _eventManager;
    private int _level = 1;

    public virtual string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public virtual int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void LogEvent(string eventName, string entity, string action, string target, float value)
    {
        // Find the GameManager object
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");

        if (gameManagerObject != null)
        {
            // Get the EventManager component from the found GameObject
            _eventManager = gameManagerObject.GetComponent<EventManager>();
        }
        else
        {
            Debug.LogWarning("EventManager object not found in the scene.");
        }

        if (_eventManager != null)
        {
            _eventManager.LogEvent(eventName, entity, action, target, value);
        }
    }
}
