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
        public float deathDuration = 1.5f;

        private bool isDead;
        private float eventTime = 0.0f;
        private SkinnedMeshRenderer render;
        private Animator anim;
        private AudioSource audi;

		private void Awake()
		{
            isDead = false;
            audi = GetComponent<AudioSource>();
            audi.PlayDelayed(Random.Range(0.1f, 2.5f));
            anim = GetComponentInChildren<Animator>();
            render = GetComponentInChildren<SkinnedMeshRenderer>();
            currentHealth = maxHealth;
		}

		private void Update()
		{
            if (isDead)
			{
                float ratio = (Time.time - eventTime) / deathDuration;
                foreach (Material mat in render.materials)
                {
                    mat.SetFloat("Vector1_155677f7378946a085f0411c1f32a2b5", Mathf.Lerp(0, 1, ratio));
                }
            }
        }

		public void Damage(int amount)
        {
            if (!isDead)
			{
                currentHealth -= amount;
                if (currentHealth <= 0)
                {
                    Die();
                }
                EffectManager.instance.SpawnEffect(1, transform.position, transform.rotation);
            }
        }

        public void Die()
        {
            isDead = true;
            eventTime = Time.time;
            audi.Stop();
            RagDoll();
            anim.enabled = false;
            
            Destroy(gameObject, deathDuration);
        }

        public void RagDoll()
        {
            GetComponent<Rigidbody>().isKinematic = false;
            gameObject.layer = 12;
            foreach (Transform child in transform)
            {
                child.gameObject.layer = 12;
            }
        }
    }
}
