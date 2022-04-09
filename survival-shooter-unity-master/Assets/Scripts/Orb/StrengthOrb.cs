using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbs
{
    public class StrengthOrb : Orb
    {
        public int baseAmount = 5;
        public int fluctuativeAmount = 15;

        override public void Pickup()
        {
            useSound.Play();
            int dmg = baseAmount + Random.Range(0, fluctuativeAmount);
            playerShooting.AddDamage(dmg);
            Remove();
        }
    }
}

