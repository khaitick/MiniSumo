using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float startingTime = 2f;
    private float spawnDelay = 2f;

    private float spawnRange = 9f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startingTime, spawnDelay);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 SpawnPoint()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0.1f, spawnPosZ);
        return randomPos;
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPoint(), transform.rotation);
    }
}
