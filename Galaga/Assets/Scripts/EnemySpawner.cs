using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    public Transform bulletPool = default;
    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    public float monsterCount;
    public float speed = default;
    
    //private Rigidbody 
    // Start is called before the first frame update
    void Start()
    {

        //Instantiate(bulletPrefab,
        //           transform.position, transform.rotation, bulletPool);
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
       // target = FindObjectOfType<PlayerController>().transform;
       //monsterCount = 0;
        timeAfterSpawn += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;


        if (timeAfterSpawn >= spawnRate && monsterCount <= 5)
        {
            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefab,
                transform.position, transform.rotation, bulletPool);

           

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
 
}
