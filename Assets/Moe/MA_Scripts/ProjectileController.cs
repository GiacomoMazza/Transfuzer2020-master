using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 100f;
    public Rigidbody2D projectileRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        projectileRigidBody.velocity = transform.right * speed * Time.deltaTime;
    }

    //when adding enemies, we'll need to know what the bullet hit
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "ShootableEnemy" ) //if we can shoot this other obj and the bullet/projectile hits, then destroy it
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject); //projectile itself is destroyed
    }

    //ISSUE: these need to destory themselves at some point
}
