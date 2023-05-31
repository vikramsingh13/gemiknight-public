using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //logs events
    //takes event entity action target [optional value]
    public virtual void LogEvent(string eventName, string entity, string action, string target, float value)
    {
        //for now we will Debug log it, later save it in local storage
        Debug.Log(eventName + " " + entity + " " + action + " " + target + " " 
            + (value != null ? value + "." : "."));
    }
}
