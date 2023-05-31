using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWand : Weapon
{
    public GameObject fireBoltPrefab;

    // Start is called before the first frame update
    void Start()
    {
        base.Name = "Wand";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //use wand attack
    public override void UseAttack(Vector3 attackDirection)
    {
        base.UseAttack(attackDirection);

        //instantiate the fire bolt prefab
        GameObject fireBoltObject = Instantiate(fireBoltPrefab, attackDirection, Quaternion.identity);
        ProjectileFireBolt fireBolt = fireBoltObject.GetComponent<ProjectileFireBolt>();

        if(fireBolt != null)
        {
            fireBolt.Fire();
        }

    }
}
