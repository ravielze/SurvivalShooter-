using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbs
{
    public class HealthOrb : Orb
    {
        public int baseAmount = 10;
        public int fluctuativeAmount = 15;

        override public void Pickup()
        {
            useSound.Play();
            int healAmount = baseAmount + Random.Range(0, fluctuativeAmount);
            playerHealth.Heal(healAmount);
            Remove();
        }
    }
}
