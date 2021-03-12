using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
     float spawnFrequency;
   public float startspawnFrequency;
    public GameObject enemy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnFrequency <= 0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            spawnFrequency = startspawnFrequency;
        }
        else
        {
            spawnFrequency -= Time.deltaTime;
        }
    }
}
