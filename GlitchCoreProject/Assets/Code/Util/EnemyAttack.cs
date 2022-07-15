using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class EnemyAttack : MonoBehaviour
    {
        public float lifeTime = 2.0f;

        bool hasHit;
        float timer = 0.0f;

        void Start()
        {
            hasHit = false;
        }

        void FixedUpdate()
        {
            timer += Time.fixedDeltaTime;
            if (timer >= lifeTime)
			{
                Destroy(this.gameObject);
			}
        }

		private void OnTriggerEnter(Collider other)
		{
            PlayerStats player = other.GetComponent<PlayerStats>();
			if (player != null && !hasHit)
			{
                Debug.Log("hit!!");
                hasHit = true;
                player.Damage(25);
                StartCoroutine(DamageDelay());
			}
		}

        IEnumerator DamageDelay()
		{
            yield return new WaitForSeconds(1);
            hasHit = false;
		}
	}
}
