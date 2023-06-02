using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : PickableItem
{
    private bool _canAttack = true;
    public float _attackCooldown = 50f;
    private float _weaponStrength;

    public virtual bool CanAttack
    {
        get { return _canAttack; }
        set { _canAttack = value; }
    }

    public virtual float AttackCooldown
    {
        get { return _attackCooldown; }
        set { _attackCooldown = value; }
    }

    public virtual float WeaponStrength
    {
        get { return _weaponStrength; }
        set { _weaponStrength = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void UseAttack(Vector3 attackDirection)
    {
        Debug.Log(" attack used! ");
    }


}
