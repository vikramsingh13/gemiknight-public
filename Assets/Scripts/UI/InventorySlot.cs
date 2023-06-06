using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Scripting; //needed for manually adding slots to inv in ui builder

public class InventorySlot : VisualElement
{
    public Image Icon;
    public string ItemGuid = "";
    private GameObject _heldItem = null;
    //private bool _hasItem = false;

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

    public InventorySlot()
    {
        // Initialize Icon with an empty or transparent sprite to avoid null ref error
        Icon = new Image { sprite = Sprite.Create(Texture2D.blackTexture, new Rect(0, 0, 1, 1), Vector2.zero) };
        Add(Icon);

        //add uss style properties to the elements
        //this is for the icon the slot will hold
        Icon.AddToClassList("slotIcon");
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
}

/* only needed for manually adding slots in the ui builder
#region UXML
[Preserve]
public class UxmlFactory : UxmlFactory<InventorySlot, UxmlTraits> { }
[Preserve]
public class UxmlTraits : VisualElement.UxmlTraits { }
#endregion
*/