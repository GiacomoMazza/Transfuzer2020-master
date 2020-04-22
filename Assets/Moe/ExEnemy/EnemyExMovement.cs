using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExMovement : MonoBehaviour
{
    [SerializeField] float enemyMovementSpd = 1.0f;
    Rigidbody2D enemyExRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        enemyExRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        enemyExRigidBody.velocity = new Vector2(enemyMovementSpd, 0.0f);
        //for enemy movement, need to add wall detection and add walls in a different "Wall" specific layer
    }
}
