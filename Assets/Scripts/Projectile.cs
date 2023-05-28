using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool _isFired = false;

    public virtual bool IsFired
    {
        get { return _isFired; }
        set { _isFired = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //fires the prefab
    public virtual void Fire()
    {
        _isFired = true;
        Debug.Log(" Projectile was fired! ");
    }
}
