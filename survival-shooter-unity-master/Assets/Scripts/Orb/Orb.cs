using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbs
{
    public abstract class Orb : MonoBehaviour
    {
        protected bool isAlive = true;
        public int duration = 5;
        protected AudioSource useSound;
        protected PlayerHealth playerHealth;
        protected PlayerMovement playerMovement;

        protected PlayerShooting playerShooting;

        protected void Remove()
        {
            isAlive = false;
            GetComponent<Collider>().enabled = false;
            transform.Translate(-Vector3.up * 10);
            Destroy(gameObject, 3f);
        }

        protected IEnumerator DeathTick()
        {
            while (isAlive && duration > 0)
            {
                duration--;
                yield return new WaitForSeconds(1);
            }
            if (isAlive)
            {
                Remove();
            }
        }

        public abstract void Pickup();

        void OnTriggerEnter(Collider other)
        {
            if (isAlive && other.GetType() == typeof(CapsuleCollider) && other.CompareTag("Player"))
            {
                Pickup();
            }
        }

        void Awake()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
            playerMovement = player.GetComponent<PlayerMovement>();
            var playerGun = GameObject.FindGameObjectWithTag("PlayerGun");
            playerShooting = playerGun.GetComponent<PlayerShooting>();
            useSound = GetComponent<AudioSource>();
            StartCoroutine(DeathTick());
        }
    }
}