using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{

    public PlayerHealth playerHealth;
    public GameObject[] orbs;
    public float spawnTime = 10f;
    public int orbSpawned = 4;

    void Awake()
    {
        OrbSpawn();
        InvokeRepeating("OrbSpawn", spawnTime, spawnTime);
    }

    public void OrbSpawn()
    {
        for (int i = 1; i <= orbSpawned; i++)
        {
            Spawn(0);
        }
    }

    void Spawn(int retry)
    {
        if (retry >= 5)
        {
            return;
        }
        if (playerHealth.currentHealth <= 0f || orbs.Length <= 0)
        {
            return;
        }

        float dx = Random.Range(-20f, 20f);
        float dz = Random.Range(-20f, 20f);
        Vector3 d = new Vector3(dx, 0.35f, dz);
        Vector3 spawnPoint = d;

        int typeOrb = Random.Range(0, orbs.Length);

        Collider[] colliders = Physics.OverlapSphere(spawnPoint, 3f);
        List<Collider> lc = new List<Collider>(colliders);
        lc = lc.FindAll(c => c.tag != "Floor" && c.tag != "Untagged");
        if (lc.Count > 0)
        {
            Spawn(retry + 1);
            return;
        }
        Instantiate(orbs[typeOrb], spawnPoint, gameObject.transform.rotation);
    }
}
