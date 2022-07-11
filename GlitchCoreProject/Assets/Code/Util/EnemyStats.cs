using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GC.GlitchCoreProject
{
    public class EnemyStats : MonoBehaviour
    {
        public int maxHealth;
        public int currentHealth;

        private SkinnedMeshRenderer render;
        private Animator anim;

		private void Awake()
		{
            anim = GetComponentInChildren<Animator>();
            render = GetComponentInChildren<SkinnedMeshRenderer>();
            for (int i = 0; i < render.materials.Length; i++)
			{
                render.materials[i] = new Material(render.materials[i]);
			}
            Debug.Log(render.materials[0].shader);
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
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<BoxEnemyController>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            anim.enabled = false;

            foreach (Material mat in render.materials)
			{
                mat.shader = Shader.Find("Shader Graphs/Diffuse");
			}
            Destroy(gameObject, 5);
        }
    }
}
