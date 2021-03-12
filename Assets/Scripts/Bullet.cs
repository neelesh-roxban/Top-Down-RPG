using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    GameObject player;
    Vector3 playerDirection;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerDirection = (player.transform.position - transform.position).normalized;
        }
        rb.velocity = playerDirection * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))

        {

            GameController.instance.playerDeath();
            Destroy(gameObject);
          
        }
        if (collision.gameObject.tag.Equals("wall"))

        {
           
            
            Destroy(gameObject);

        }
    }

}
