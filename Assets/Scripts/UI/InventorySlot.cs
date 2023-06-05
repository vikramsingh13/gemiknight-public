using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Scripting;

public class InventorySlot : VisualElement
{
    public Image Icon;
    public string ItemGuid = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public InventorySlot()
    {
        Icon = new Image();
        Add(Icon);

        //add uss style properties to the elements
        //this is for the icon the slot will hold
        Icon.AddToClassList("slotIcon");
    }
}

#region UXML
[Preserve]
public class UxmlFactory : UxmlFactory<InventorySlot, UxmlTraits> { }
[Preserve]
public class UxmlTraits : VisualElement.UxmlTraits { }
#endregion
