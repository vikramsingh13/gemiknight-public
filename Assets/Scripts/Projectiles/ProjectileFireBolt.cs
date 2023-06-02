using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFireBolt : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        base.ProjectileSpeed = 10f;
        base.ProjectileRange = .5f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (base.IsPaused)
        {
            return; //skip when game is paused
        }
    }

    //fires the prefab
    public override void Fire()
    {
        if (base.IsPaused)
        {
            return; //skip when game is paused
        }
        base.Fire();
    }

    //checks if it gets hit by player 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<BlobBlue>().ReduceHealth(500);

            // Destroy the projectile
            Destroy(this.gameObject);
        }
    }
}
