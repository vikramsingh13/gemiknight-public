using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFireBolt : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        base.ProjectileSpeed = 10f;
        base.ProjectileRange = 5f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    //fires the prefab
    public override void Fire()
    {
        base.Fire();
    }
}
