using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Entity
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Delete()
    {
        Destroy(this.gameObject);
    }

    public virtual void Display()
    {
        //to do
        Debug.Log("Displaying " + base.Name);
    }
}
