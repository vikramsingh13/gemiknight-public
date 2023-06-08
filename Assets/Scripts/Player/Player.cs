using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    private Weapon _equippedWeapon;
    private PlayerInventory _inventory;
    public Vector2 PointerInput;
    private WeaponParent _weaponParent;
    private SpriteRenderer _equippedWeaponRenderer;
    private int _playerInventorySize;

    public virtual Weapon EquippedWeapon
    {
        get { return _equippedWeapon; }
        set { _equippedWeapon = value; }
    }

    public virtual PlayerInventory Inventory
    {
        get { return _inventory; }
        set { _inventory = value; }
    }

    public virtual int PlayerInventorySize
    {
        get { return _playerInventorySize; }
        set { _playerInventorySize = value; }
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        base.Name = "zPoc";
        base.Level = 12;
        Inventory = this.GetComponent<PlayerInventory>();
        PointerInput = GetPointerInput();
        _equippedWeaponRenderer = GameObject.FindWithTag("PlayerWeapon").GetComponent<SpriteRenderer>();
        PlayerInventorySize = 21;
    }

    private void Awake()
    {
        _weaponParent = GetComponentInChildren<WeaponParent>();
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

        //set pointerinput to mouse position
        PointerInput = GetPointerInput();
        _weaponParent.WeaponPointerPosition = PointerInput;
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
        Debug.Log(" weapon in player equipweapon " + weapon.GetType());
        if ( weapon == null || weapon.IsEquippable == false ) { return false; }

        if (weapon.LevelRequired <= base.Level)
        {
            if( EquippedWeapon != null)
            {
                //weapon will be replaced by currently equipped weapon in the inventory
                Inventory.SwapGear(weapon, EquippedWeapon);
                EquippedWeapon.LogUnequip();
            }
            
            //equipped weapon either started as null, or is null now after swap
            //set it to the new weapon
            EquippedWeapon = weapon;
            EquippedWeapon.LogEquip();
            ChangeEquippedWeaponSprite(weapon);
            StartCoroutine(ResetAttack());
            return true;
        }
        else
        {
            weapon.LogCantEquip();
            return false;
        }
    }

    private void ChangeEquippedWeaponSprite(Weapon weapon)
    {
        //update the equipped weapon sprite
        _equippedWeaponRenderer.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }


}
