using UnityEngine;
using System.Collections;

public class BomberAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public AudioClip explosionClip;
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    AudioSource enemyAudio;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        // Mendapatkan Enemy health
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Callback jika ada suatu object masuk ke dalam trigger
    void OnTriggerEnter(Collider other)
    {
        // Set player in range
        if (other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;

        }
    }

    // Callback jika ada object yang keluar dari trigger
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = false;
        }
    }


    void Update()
    {

        if (playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {

        // Taking damage
        if (playerHealth.currentHealth > 0)
        {
            enemyAudio.clip = explosionClip;
            enemyAudio.Play();
            playerHealth.TakeDamage(attackDamage);
            enemyHealth.currentHealth = -1;
            
        }

    }
}
