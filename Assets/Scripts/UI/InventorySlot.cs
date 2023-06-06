using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Scripting; //needed for manually adding slots to inv in ui builder

public class InventorySlot : VisualElement
{
    public Image Icon;
    private GameObject _heldItem = null;
    //private bool _hasItem = false;
    private Player _player;

    public virtual GameObject HeldItem
    {
        get { return _heldItem; }
        set { _heldItem = value; }
    }

    /* no need, we only check if HeldItem is null or not
    public virtual bool HasItem
    {
        get { return _hasItem; }
        set { _hasItem = value; }
    }*/

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public InventorySlot(Player player)
    {
        // Initialize Icon with an empty or transparent sprite to avoid null ref error
        Icon = new Image { sprite = Sprite.Create(Texture2D.blackTexture, new Rect(0, 0, 1, 1), Vector2.zero) };
        Add(Icon);

        //add uss style properties to the elements
        //this is for the icon the slot will hold
        Icon.AddToClassList("slotIcon");

        _player = player;

        //Mouseclick event listener
        RegisterCallback<PointerDownEvent>(OnPointerDown);
    }

    //takes the gameobject as item
    //saves the item's sprite in the invslot icon's sprite
    //also store a ref to the item in HeldItem
    public void HoldItem(GameObject item)
    {
        Icon.sprite = item.GetComponent<SpriteRenderer>().sprite;
        HeldItem = item;
    }

    //clears HeldItem and Icon.sprite
    public void DropItem()
    {
        if (HeldItem != null)
        {
            HeldItem = null;
            //cannot make the sprite null because of runtime null ref error
            Icon.sprite = GetEmptySprite();
        }
    }

    //returns an empty sprite
    private Sprite GetEmptySprite()
    {
        // Create an empty or transparent texture
        Texture2D texture = new Texture2D(1, 1);
        Color32[] pixels = new Color32[1] { Color.clear };
        texture.SetPixels32(pixels);
        texture.Apply();

        // Create a sprite using the empty or transparent texture
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        Vector2 pivot = new Vector2(0.5f, 0.5f);
        Sprite sprite = Sprite.Create(texture, rect, pivot);

        return sprite;
    }

    private void OnPointerDown(PointerDownEvent evt)
    {
        Debug.Log("point down in Inv Slot " + evt.button);
        //Not the left mouse button or this is an empty slotIn
        if (evt.button != 0 || HeldItem == null)
        {
            return;
        }

        Debug.Log("point down in Inv Slot " + HeldItem.GetType());
        if (HeldItem != null)
        {
            // Get all script components of the desired type
            Component[] scriptComponents = HeldItem.GetComponents<Component>();
            Debug.Log("point down in Inv Slot scriptcomp " + scriptComponents);
            // Iterate through the script components and filter based on the name
            foreach (Component component in scriptComponents)
            {
                Debug.Log("point down in Inv Slot compo " + scriptComponents);
                if (component.GetType().Name.Contains("Weapon"))
                {
                    //for now we equip the weapon, later, a context menu will drop on right click
                    if (_player.EquipWeapon((Weapon)component))
                    {
                        //Clear the sprite
                        Icon.sprite = GetEmptySprite();

                        HeldItem = null;

                    }
                }
            }
        }

        //Start the drag
        //InventoryUIController.StartDrag(evt.position, this);
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