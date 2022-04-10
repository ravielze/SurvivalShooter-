using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private int waveNumber = 0;


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

    public int[,] mtx_enemy = new int[10,3] {
        {1,0,0},
        {2,1,0},
        {3,3,0},
        {3,2,1},
        {4,3,1},
        {4,5,2},
        {6,5,3},
        {6,6,4},
        {8,8,6},
        {8,8,8},
    };

    void Start ()
    {
        //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
        // InvokeRepeating("Spawn", spawnTime, spawnTime);
        StartWave();
        StartCoroutine(checkWave());
    }


    void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        enemySpawned++;
        if (waveNumber > 10){
            int num_above = (waveNumber - 10) + 1 ;
            // Menduplikasi enemy bunny
            for (int i = 0; i < mtx_enemy[9,0] * num_above; i++){
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                Instantiate(Zombunny, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            // Menduplikasi enemy bear
            for (int i = 0; i < mtx_enemy[9,1] * num_above; i++){
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                Instantiate(ZomBear, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            // Menduplikasi enemy hellephant
            for (int i = 0; i < mtx_enemy[9,2] * num_above; i++){
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                Instantiate(Hellephant, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
        }else{
            // Menduplikasi enemy bunny
            for (int i = 0; i < mtx_enemy[waveNumber-1,0]; i++){
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                Instantiate(Zombunny, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            // Menduplikasi enemy bear
            for (int i = 0; i < mtx_enemy[waveNumber-1,1]; i++){
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                Instantiate(ZomBear, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            // Menduplikasi enemy hellephant
            for (int i = 0; i < mtx_enemy[waveNumber-1,2]; i++){
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                Instantiate(Hellephant, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
        }
        
    }
    void StartWave(){
        Debug.Log(mtx_enemy[0,0]);
        Debug.Log(mtx_enemy[0,1]);
        Debug.Log(mtx_enemy[0,2]);
        waveNumber = 1;
        Spawn();
        // for (int i = 0; i < enemySpawnAmount; i++){
        //     Spawn();
        // }
        
    }
    public void NextWave(){
        waveNumber++;
        Debug.Log(mtx_enemy[waveNumber-1,0]);
        Debug.Log(mtx_enemy[waveNumber-1,1]);
        Debug.Log(mtx_enemy[waveNumber-1,2]);
        Spawn();
        // for (int i = 0; i < enemySpawnAmount; i++){
        //     Spawn();
        // }
    }
    public IEnumerator checkWave(){
        while ( true ){
            if (enemySpawned == 0){
                Debug.Log("nextwave");
                NextWave();
            }else{
                Debug.Log("wait");
                yield return new WaitForSeconds(1);
            }
        }
    } 
}


