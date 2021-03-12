using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

     float frequencyofbullets;
    public float startfrequencyofbullets;
    public GameObject deatheffect;
     GameObject Player;
    float speed;
    public GameObject bullet;
    Rigidbody2D rb;
    
    Vector3 targetDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(0.8f,1.5f);
    }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
       
        frequencyofbullets = startfrequencyofbullets;
    }
    private void Update()
    { if (Player != null)
        {
            targetDirection = (Player.transform.position - gameObject.transform.position).normalized;
        }
        
        shoot();
       

    }
    private void FixedUpdate()
    {
        rb.velocity = targetDirection * speed;
    }

    void shoot()
    {

        if (frequencyofbullets <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            frequencyofbullets = startfrequencyofbullets;
        }
        else
        {
            frequencyofbullets -= Time.deltaTime;
        }
    }
    

        public void die()
    {
        Instantiate(deatheffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
       

    }
}
