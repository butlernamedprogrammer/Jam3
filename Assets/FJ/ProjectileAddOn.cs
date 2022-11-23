using JAM3.Health;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddOn : MonoBehaviour
{
    private Rigidbody rb;
    private bool targetHit;
    private Item item;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        item = GetComponent<Item>();
        Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        //make sure only to stick to the first target you hit
        if (targetHit && collision.gameObject.layer == 28)
            return;
        else
            targetHit = true;

        //make sure projectile sticks to surface

        rb.isKinematic = true;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        Vector3 aux = collision.GetContact(0).point;
        collision.gameObject.GetComponent<Enemy>().TakeDamage(item.value, aux);
        


        //make sure projectile moves with target
        
        transform.SetParent(collision.transform.GetChild(0));
        

        Destroy(gameObject, 5f);
    }
}