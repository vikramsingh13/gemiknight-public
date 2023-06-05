using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUIController : MonoBehaviour
{
    private VisualElement _root;
    private VisualElement _slotContainer;

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
            InventorySlot item = new InventorySlot();

            InventoryItems.Add(item);

            _slotContainer.Add(item);
        }

        Debug.Log("inv ui cont slot container after slot add " + _slotContainer);

    }
}
