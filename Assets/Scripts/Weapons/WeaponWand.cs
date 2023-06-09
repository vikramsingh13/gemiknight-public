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
        base.Level = 10;
        base.LevelRequired = 10;
        base.AttackCooldown = 100f;
        base.WeaponStrength = 500;
        base.AssociatedGameObject = gameObject;
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
    }

    //use wand attack
    public override void UseAttack(Vector3 attackDirection)
    {
        if (base.IsPaused)
        {
            return; //skip when game is paused
        }
        //instantiate the fire bolt prefab
        GameObject fireBoltObject = Instantiate(fireBoltPrefab, attackDirection, Quaternion.identity);
        ProjectileFireBolt fireBolt = fireBoltObject.GetComponent<ProjectileFireBolt>();
        if(fireBolt != null)
        {
            fireBolt.Fire();
        }
    }
}
