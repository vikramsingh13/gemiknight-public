using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Scripting; //needed for manually adding slots to inv in ui builder

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

/* only needed for manually adding slots in the ui builder
#region UXML
[Preserve]
public class UxmlFactory : UxmlFactory<InventorySlot, UxmlTraits> { }
[Preserve]
public class UxmlTraits : VisualElement.UxmlTraits { }
#endregion
*/