using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject spider;
    public Text waveNumberr;

    public int[,] mtx_enemy = new int[10,4] {
        {1,1,0,0},
        {2,1,1,0},
        {3,3,2,1},
        {4,3,3,2},
        {5,5,4,2},
        {6,6,4,3},
        {6,6,6,4},
        {6,6,4,4},
        {8,8,6,6},
        {8,8,8,8},
    };

    void Start ()
    {
        StartWave();
        StartCoroutine(checkWave());
    }


    void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        if (waveNumber > 10){
            int num_above = (waveNumber - 10) + 1 ;
            // Menduplikasi enemy bunny
            for (int i = 0; i < mtx_enemy[9,0] * num_above; i++){
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                enemySpawned++;
                Instantiate(Zombunny, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            // Menduplikasi enemy bear
            for (int i = 0; i < mtx_enemy[9,1] * num_above; i++){
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                enemySpawned++;
                Instantiate(ZomBear, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            // Menduplikasi enemy hellephant
            for (int i = 0; i < mtx_enemy[9,2] * num_above; i++){
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                enemySpawned++;
                Instantiate(Hellephant, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            // Menduplikasi enemy spider
            for (int i = 0; i < mtx_enemy[9,3] * num_above; i++){
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                enemySpawned++;
                Instantiate(spider, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
        }else{
            // Menduplikasi enemy bunny
            for (int i = 0; i < mtx_enemy[waveNumber-1,0]; i++){
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                enemySpawned++;
                Instantiate(Zombunny, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            // Menduplikasi enemy bear
            for (int i = 0; i < mtx_enemy[waveNumber-1,1]; i++){
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                enemySpawned++;
                Instantiate(ZomBear, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            // Menduplikasi enemy hellephant
            for (int i = 0; i < mtx_enemy[waveNumber-1,2]; i++){
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                enemySpawned++;
                Instantiate(Hellephant, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            // Menduplikasi enemy spider
            for (int i = 0; i < mtx_enemy[waveNumber-1,3]; i++){
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                enemySpawned++;
                Instantiate(spider, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
        }
        
    }
    void StartWave(){
        // Debug.Log(mtx_enemy[0,0]);
        // Debug.Log(mtx_enemy[0,1]);
        // Debug.Log(mtx_enemy[0,2]);
        // Debug.Log(mtx_enemy[0,3]);
        waveNumber = 1;
        waveNumberr.text = waveNumber.ToString();
        Spawn();
        
    }
    public void NextWave(){
        waveNumber++;
        waveNumberr.text = waveNumber.ToString();
        // Debug.Log(mtx_enemy[waveNumber-1,0]);
        // Debug.Log(mtx_enemy[waveNumber-1,1]);
        // Debug.Log(mtx_enemy[waveNumber-1,2]);
        // Debug.Log(mtx_enemy[waveNumber-1,3]);
        Spawn();
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


