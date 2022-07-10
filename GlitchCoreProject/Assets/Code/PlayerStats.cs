using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class PlayerStats : MonoBehaviour
    {
        public int maxHealth = 100;
        public float currentHealth;
        public int money = 50;

        [Header("Modifiers")]
        public float maxHealthMod = 1;
        public float moveSpeedMod = 1;
        public float fireDelayMod = 1;
        public float jumpHeightMod = 1;
        public float airControlMod = 1;

		private void Awake()
		{
            currentHealth = maxHealth;
		}

		public void Damage(int amount)
		{
            currentHealth -= amount;
            if (currentHealth <= 0)
			{
                Die();
			}
		}

        public void Die()
		{
            SceneChanger.LoadLevel("Menu");
		}
    }
}
