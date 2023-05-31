using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    private WeaponWand wand;

    // Start is called before the first frame update
    void Start()
    {
        base.Name = "zPoc";
        wand = GameObject.FindGameObjectWithTag("WeaponWand").GetComponent<WeaponWand>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal and vertical input
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        //movement vector
        Vector2 movement = new Vector2(moveX, moveY) * moveSpeed;

        //move
        rb.velocity = movement;
    }

    //use the equipped weapon's attack
    public virtual void UseAttack()
    {
        if (wand.CanAttack)
        {
            wand.UseAttack(transform.position);
            wand.CanAttack = false;
            StartCoroutine(ResetAttack());
        }
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(wand.AttackCooldown * Time.deltaTime);
        wand.CanAttack = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
        }
    }
}
