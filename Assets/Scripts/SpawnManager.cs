using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefab;
    public GameObject powerup;


    private float spawnRange = 9f;
    private int enemyCount;
    private int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(waveNumber);
    }
    

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount <= 0)
        {
            waveNumber++;
            SpawnEnemy(waveNumber);
        }
    }

    public Vector3 SpawnPoint()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0.1f, spawnPosZ);
        return randomPos;
    }

    public void SpawnEnemy(int spawnCount)
    {
        // spawn powerup
        Instantiate(powerup, SpawnPoint(), powerup.transform.rotation);

        // Spawn boss
        if (waveNumber % 3 == 0)
        {
            spawnCount--;
            Instantiate(enemiesPrefab[1], SpawnPoint(), transform.rotation);
        }

        // Spawn enemy
        for (int i = 0; i < spawnCount; i++){
            Instantiate(enemiesPrefab[0], SpawnPoint(), transform.rotation);
        }
    }
}
