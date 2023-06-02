using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            projectile = collision.gameObject;
            Debug.Log("collision proj: " +  projectile.name);
            player = GameObject.Find("Player");

            // Disable the collider of the projectile
            Collider2D projectileCollider = projectile.GetComponent<Collider2D>();
            projectileCollider.enabled = false;
        }
    }
}
