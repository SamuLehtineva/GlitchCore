using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class EnemyStats : MonoBehaviour
    {
        public int maxHealth;
        public int currentHealth;

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
            EffectManager.instance.SpawnEffect(1, transform.position, transform.rotation);
        }

        public void Die()
        {
            Destroy(this.gameObject);
        }
    }
}
