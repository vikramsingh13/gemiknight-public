using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private string _name = string.Empty;
    private EventManager _eventManager;
    private int _level = 1;
    private GameController _gameController;
    private bool _isPaused;

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

    public virtual bool IsPaused
    {
        get { return _isPaused; }
        set { _isPaused = value; }
    }

    // Start is called before the first frame update
    public void Start()
    {
        _gameController = GameObject.FindWithTag("GameManager").GetComponent<GameController>();
        Debug.Log("entite game contr " + _gameController);

    }

    // Update is called once per frame
    public void Update()
    {
        if(_gameController != null)
        {
            if(IsPaused != _gameController.IsPaused)
            {
                IsPaused = _gameController.IsPaused;
            }
        }
        else
        {
            _gameController = GameObject.FindWithTag("GameManager").GetComponent<GameController>();
        }

        if (IsPaused)
        {
            return; //skip when paused
        }
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
