using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUIController : MonoBehaviour
{
    private VisualElement _root;
    private VisualElement _slotContainer;
    private Player _player;
    private ControlSettings _controlSettings;

    public List<InventorySlot> InventoryItems = new List<InventorySlot>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        //store the ref for player that will be passed to the inv slots
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //ref of the control settings from GameManager
        _controlSettings = GameObject.FindWithTag("GameManager").GetComponent<ControlSettings>();

        //store root from UI document
        _root = GameObject.FindGameObjectWithTag("UIRuntime").GetComponent<UIDocument>().rootVisualElement;

        //search the root for slotcontainer visual element
        _slotContainer = _root.Q<VisualElement>("InventorySlotContainer");

        Debug.Log("inv ui cont root " + _root);
        Debug.Log("inv ui cont slot container " + _slotContainer);
        //create inventoryslots and add them as children to slot container
        //TO DO : refactor number of slots as an attribute from player class
        for (int i = 0; i < 21; i++)
        {
            Debug.Log("slots being added in inv ui cont");
            InventorySlot slot = new InventorySlot(_player);

            InventoryItems.Add(slot);

            _slotContainer.Add(slot);
        }

        Debug.Log("inv ui cont slot container after slot add " + _slotContainer);

    }

    //adds the new items 
    public void Add(GameObject item)
    {
        //iterate through the InventorySlots and add the item to first available slot
        foreach(InventorySlot slot in InventoryItems)
        {
            if(slot.HeldItem == null)
            {
                slot.HoldItem(item);
                return;
            }
        }

        return;
    }

    //Drop item can be directly programmed in InventorySlot DropItem
}
