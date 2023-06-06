using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Player _player;
    private List<PickableItem> _inventory = new List<PickableItem>(); //array stores refs to pickable items in inv
    private InventoryUIController _invUIController; //updates the runtime inventory ui

    public virtual List<PickableItem> Inventory
    {
        get { return _inventory; }
        set { _inventory = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _invUIController = GameObject.FindGameObjectWithTag("UIRuntime").GetComponent<InventoryUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual bool Add(PickableItem item, int stackSize )
    {
        int originalStackSize = stackSize; //keep the original number handy for logging after pickup 

        if (item.IsStackable)
        {
            //loop through inventory for stackable items of same name
            foreach(PickableItem invItem in Inventory)
            {
                //if the name matches to increase the stack of the existing item
                //and decrease it from the new pile we are trying to add
                if(invItem.Name == item.Name)
                {
                    //TODO create function in InventoryUIController to update
                    //the stackSize visual
                    if (invItem.MaxStack - invItem.StackSize >= stackSize)
                    {
                        //remaining space is more than the stack being added
                        //so the whole stack is being added onto the same pile 
                        invItem.StackSize += stackSize;
                        stackSize = 0;
                    }
                    else
                    {
                        //remaining space in that stack is filled
                        //the remaining space is being removed
                        stackSize = stackSize - (invItem.MaxStack - invItem.StackSize);
                        invItem.StackSize = invItem.MaxStack;
                    }
                }

                if (stackSize <= 0)
                {
                    item.LogPickup(originalStackSize);
                    //this item's stack is 0, remove the stack from game
                    item.Delete();
                    return true;
                }
            }                
        }

        //if function runs upto this point, means there is atleast 1 item...
        //...left in the stack
        //the initial item's stackSize will never be larger than it's maxStack
        //so the left over stack is less or equal to the maxStack
        //therefore, if there is atleast 1 inv slot free, we add the stack to it
        if (Inventory.Count < _player.PlayerInventorySize)
        {
            Inventory.Add(item);
            Debug.Log(item.AssociatedGameObject);
            _invUIController.Add(item.AssociatedGameObject);
            item.LogPickup(originalStackSize);
            return true;
        }

        return false;
    }

    //takes the item ref and the number of stack size need to be reduced
    public virtual bool Drop(PickableItem item, int value=1)
    {
        if(item.MaxStack <= 1 || item.StackSize <= value)
        {
            Inventory.Remove(item);
            item.LogDrop(item.MaxStack <= 1 ? item.MaxStack : item.StackSize);
            return true;
        }
        if(item.StackSize > value)
        {
            item.LogDrop(value);
            item.StackSize = item.StackSize - value;
            return true;
        }

        return false;
    }

    //weapon in the inventory will be equipped by player
    //so weapon is removed from inventory. equippedWeapon is added instead
    public virtual bool SwapGear(Weapon weapon, Weapon equippedWeapon)
    {
        //To do implement
        return true;
    }
}
