using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool _canAttack = true;
    private float _attackCooldown = 1f;

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
