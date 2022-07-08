using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class PlayerStats : MonoBehaviour
    {
        public int maxHealth = 100;
        public int money = 50;

        [Header("Modifiers")]
        public float maxHealthMod = 1;
        public float moveSpeedMod = 1;
        public float fireDelayMod = 1;
        public float jumpHeightMod = 1;
        public float airControlMod = 1;
    }
}
