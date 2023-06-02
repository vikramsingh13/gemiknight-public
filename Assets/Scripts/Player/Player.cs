using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    private Weapon _equippedWeapon;
    private PlayerInventory _inventory;

    public virtual Weapon EquippedWeapon
    {
        get { return _equippedWeapon; }
        set { _equippedWeapon = value; }
    }

    public virtual PlayerInventory Inventory
    {
        get { return this._inventory; }
        set { this._inventory = value; }
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        base.Name = "zPoc";
        base.Level = 12;
        Inventory = this.GetComponent<PlayerInventory>();

    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (base.IsPaused)
        {
            return; //skip when game is paused
        }
        //horizontal and vertical input
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        //movement vector
        Vector2 movement = new Vector2(moveX, moveY) * moveSpeed;

        //move
        rb.velocity = movement;
    }

    //use the equipped weapon's attack
    public virtual void UseAttack()
    {
        if (base.IsPaused)
        {
            return; //skip when game is paused
        }
        if (EquippedWeapon != null && EquippedWeapon.CanAttack)
        {
            EquippedWeapon.UseAttack(this.transform.position);
            EquippedWeapon.CanAttack = false;
            StartCoroutine(ResetAttack());
        }
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(EquippedWeapon.AttackCooldown * Time.deltaTime);
        EquippedWeapon.CanAttack = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (base.IsPaused)
        {
            return; //skip when game is paused
        }
        if (collision.gameObject.tag == "Projectile")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
        }
    }

    public virtual bool EquipWeapon(Weapon weapon)
    {
        if (base.IsPaused)
        {
            return false; //skip when game is paused
        }
        if ( weapon == null || weapon.IsEquippable == false ) { return false; }

        if (weapon.LevelRequired <= base.Level)
        {
            if( EquippedWeapon != null)
            {
                bool _ = Inventory.Add(EquippedWeapon, EquippedWeapon.StackSize);
                if( _ == false)
                {
                    EquippedWeapon.LogUnequip();
                    EquippedWeapon.Drop();
                }
            }
            EquippedWeapon = weapon;
            weapon.LogEquip();
            return true;
        }
        else
        {
            weapon.LogCantEquip();
            return false;
        }
    }


}
