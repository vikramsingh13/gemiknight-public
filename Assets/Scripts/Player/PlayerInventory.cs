using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Player _player;
    private List<PickableItem> _inventory; //array stores refs to pickable items in inv

    public virtual List<PickableItem> Inventory
    {
        get { return _inventory; }
        set { _inventory = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual bool Add(PickableItem item, int stackSize )
    {
        //first check if item exists in Inventory
          //if true, check if item.IsStackable && item.MaxStack - item.StackSize <= stackSize
            //if true change item in inv .StackSize += stackSize
        //then check if space in Inventory
          //if true check if space <= rounded up item.StackSize / item.MaxStack
            //add items
          //else 
            //fill up all the space with item upto maxstack each
            //and drop stackSize - space * item.MaxStack
        //else
          //return false
        
        return true;
    }
}
