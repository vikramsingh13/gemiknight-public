using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : Item
{
    private bool _isStackable = false;
    private int _maxStack = 1;
    private bool _isDropped = false;
    private int _stackSize = 1;
    private GameObject _player; //will be used to get player's inventory, and for logging
    private int _levelRequired = 1;
    private bool _isEquippable = true;

    public virtual bool IsStackable
    {
        get { return _isStackable; }
        set { _isStackable = value; }
    }

    public virtual int MaxStack
    {
        get { return _maxStack; }
        set { _maxStack = value; }
    }

    public virtual bool IsDropped
    {
        get { return _isDropped; }
        set { _isDropped = value; }
    }

    public virtual int StackSize
    {
        get { return _stackSize; }
        set { _stackSize = value; }
    }

    public virtual int LevelRequired
    {
        get { return _levelRequired; }
        set { _levelRequired = value; }
    }

    public virtual bool IsEquippable
    {
        get { return _isEquippable; }
        set { _isEquippable = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        IsDropped = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //expects the player game object's inventory component
    //returns true if player inv picked it up or false o/w
    public virtual bool Pickup(PlayerInventory inv, int quantity)
    {
        if (inv.Add(this, quantity))
        {
            IsDropped = false;
            LogPickup();
            Display();
            return true;
        } else
        {
            IsDropped = true;
            Display();
            return false;
        }
    }

    //return true if it was dropped
    //both player inv and mobs can use this
    public virtual bool Drop()
    {
        IsDropped = true;
        LogDrop();
        Display();
        return true;
    }

    //overrides the base display method to display only when dropped
    //hides when not displayed 
    public override void Display()
    {
        if (IsDropped)
        {
            this.gameObject.SetActive(true);
        } else
        {
            this.gameObject.SetActive(false);
        }
    }

    //deals with collision with player
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.gameObject;
            if(_player != null)
            {
                PlayerInventory inv = _player.GetComponent<PlayerInventory>();
                Pickup(inv, StackSize);
                Player _ = _player.GetComponent<Player>();
                _.EquipWeapon(this.gameObject.GetComponent<Weapon>());
            }
        }
    }

    //log pickup
    public virtual void LogPickup()
    {
        Player _ = _player.GetComponent<Player>();
        base.LogEvent("PICKUP", _.Name, "picked up", base.Name, StackSize);
    }

    //log drop
    public virtual void LogDrop()
    {
        Player _ = _player.GetComponent<Player>();
        base.LogEvent("DROP", _.Name, "dropped", base.Name, StackSize);
    }

    //log equip
    public virtual void LogEquip()
    {
        Player _ = _player.GetComponent<Player>();
        base.LogEvent("EQUIP", _.Name, "equipped", base.Name, StackSize);
    }

    //log unequip
    public virtual void LogUnequip()
    {
        Player _ = _player.GetComponent<Player>();
        base.LogEvent("UNEQUIP", _.Name, "unequipped", base.Name, StackSize);
    }

    //log cant equip
    public virtual void LogCantEquip()
    {
        Player _ = _player.GetComponent<Player>();
        base.LogEvent("CAN'T EQUIP", _.Name, "can't equip weapon. Player level not high enough.", base.Name, LevelRequired);
    }
}
