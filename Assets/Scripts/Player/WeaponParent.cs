using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 WeaponPointerPosition { get; set; }
    public SpriteRenderer characterRenderer, weaponRenderer;

    // Start is called before the first frame update
    void Start()
    {
        characterRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        weaponRenderer = GameObject.FindWithTag("PlayerWeapon").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {   
        //get the directin of the mouse pointer
        Vector2 direction = (WeaponPointerPosition- (Vector2)transform.position).normalized;
        //set it to weapon transform, so weapon faces mouse
        transform.right = direction;

        //make sure weapon sprite is flipped horizontally instead of vertically
        Vector2 scale = transform.localScale;
        if(direction.x < 0)
        {
            scale.y = -1;
        }
        else if(direction.x > 0) 
        {
            scale.y = 1;
        }
        transform.localScale = scale;

        //hide weapon behind player character's head
        if(transform.eulerAngles.z > 45 && transform.eulerAngles.z < 135) 
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
        }
    }


}
