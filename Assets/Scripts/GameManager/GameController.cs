using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool _isPaused = false;
    private ControlSettings _controlSettings;

    public virtual bool IsPaused
    {
        get { return _isPaused; }
        set { _isPaused = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _controlSettings = GetComponent<ControlSettings>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_controlSettings.EscapeKey))
        {
            
            IsPaused = !IsPaused;
            Debug.Log("game controller : " + IsPaused);
            if (IsPaused)
            {
                return;
            }
        }
    }

    public void ResumeGame()
    {
        Debug.Log("ResumeGame called in Gamecontroller ");
    }
}
