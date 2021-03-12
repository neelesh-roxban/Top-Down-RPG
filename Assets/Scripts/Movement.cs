using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float speed;
    private Rigidbody2D rb;
    private Vector3 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1;
        }
        moveDir = new Vector3(moveX, moveY).normalized;
    }
    private void FixedUpdate()
    {
        rb.velocity = moveDir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))

        {
            
            GameController.instance.playerDeath();
            

        }
    }
}
