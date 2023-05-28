using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFireBolt : Projectile
{
    private Vector3 targetDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (base.IsFired)
        {
            transform.position += targetDirection * 8f * Time.deltaTime;
        }
    }

    //fires the prefab
    public override void Fire()
    {
        base.Fire();

        //calculate current mouse pointer position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetDirection = (mousePosition - transform.position).normalized;
    }
}
