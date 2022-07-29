using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class PlayerStats : MonoBehaviour
    {
        public static PlayerStats instance;
        public int maxHealth = 100;
        public int currentHealth;
        public int money = 50;

        [Header("Modifiers")]
        public float maxHealthMod = 1;
        public float moveSpeedMod = 1;
        public float fireDelayMod = 1;
        public float jumpHeightMod = 1;
        public float airControlMod = 1;

		private void Awake()
		{
            instance = this;
            currentHealth = maxHealth;
		}

		public void Damage(int amount)
		{
            currentHealth -= amount;
            if (currentHealth <= 0)
			{
                Die();
			}
            UIManager.instance.healthTxt.text = "Health: " + currentHealth;
		}

        public void Die()
		{
            SceneChanger.LoadLevel("Menu");
		}
    }
}
