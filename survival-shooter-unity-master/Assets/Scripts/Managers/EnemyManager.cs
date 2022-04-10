using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    private static int waveNumber = 0;


    public PlayerHealth playerHealth;
    // public GameObject enemy;
    public int spawnEnemy;
    public int enemySpawned = 0;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    // [SerializeField]
    // public MonoBehaviour factory;
    // IFactory Factory { get { return factory as IFactory; } }
    public GameObject ZomBear;
    public GameObject Zombunny;
    public GameObject Hellephant;
    public GameObject spider;

    public int[,] mtx_enemy = new int[10, 4] {
        {1,1,0,0},
        {2,1,1,0},
        {3,3,2,1},
        {4,3,3,0},
        {5,5,4,0},
        {6,6,4,2},
        {6,6,6,0},
        {6,6,4,0},
        {8,8,6,3},
        {8,8,8,0},
    };

    void Start()
    {
        StartWave();
        StartCoroutine(checkWave());
    }

    public int EnemiesSpawned()
    {
        return enemySpawned;
    }

    public static int Wave()
    {
        return waveNumber;
    }

    public void EnemyDeath()
    {
        enemySpawned--;
    }

    private void SpawnEntities(GameObject obj, int count)
    {
        if (count < 0)
        {
            return;
        }
        enemySpawned += count;
        for (int i = 0; i < count; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(obj, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }


    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        if (waveNumber > 10)
        {
            int num_above = (waveNumber - 10) + 1;
            SpawnEntities(Zombunny, mtx_enemy[9, 0] * num_above);
            SpawnEntities(ZomBear, mtx_enemy[9, 1] * num_above);
            SpawnEntities(Hellephant, mtx_enemy[9, 2] * num_above);
        }
        else
        {
            SpawnEntities(Zombunny, mtx_enemy[waveNumber - 1, 0]);
            SpawnEntities(ZomBear, mtx_enemy[waveNumber - 1, 1]);
            SpawnEntities(Hellephant, mtx_enemy[waveNumber - 1, 2]);
        }

    }
    void StartWave()
    {
        waveNumber = 1;
        enemySpawned = 0;
        Spawn();

    }
    public void NextWave()
    {
        waveNumber++;
        Spawn();
    }
    public IEnumerator checkWave()
    {
        while (true)
        {
            if (enemySpawned == 0)
            {
                NextWave();
            }
            else
            {
                yield return new WaitForSeconds(1);
            }
        }
    }
}


