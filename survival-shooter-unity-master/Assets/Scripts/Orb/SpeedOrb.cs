using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orbs
{
    public class SpeedOrb : Orb
    {
        public float speedAmount = 0.25f;

        override public void Pickup()
        {
            useSound.Play();
            playerMovement.IncreaseSpeed(speedAmount);
            Remove();
        }
    }
}

