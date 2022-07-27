using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class Bullet_3 : MonoBehaviour
    {
        public float speed;
        public float lifeTime;
        public float explosionRadius;
        public float explosionForce;

        float timer = 0.0f;
        int layerMask = (1 << 7) | (1 << 3) | (1 << 12);

        void Update()
        {
            timer += Time.deltaTime;
            transform.position += transform.forward * speed * Time.deltaTime;
            CheckHit();

            if (timer >= lifeTime)
			{
                Destroy(this.gameObject);
			}
        }

        void CheckHit()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 0.15f, ~layerMask))
            {
                if (hit.transform.gameObject.layer == 6)
				{
                    DecalManager.instance.CreateDecal(hit, 0);
                }

                EffectManager.instance.SpawnEffect(2, transform.position, transform.rotation);
                Explode();
                Destroy(this.gameObject);
            }
        }

        void Explode()
		{
            Collider[] objectsInRange = Physics.OverlapSphere(transform.position, explosionRadius);

            foreach (Collider col in objectsInRange)
			{
                EnemyStats stats = col.GetComponent<EnemyStats>();
                if (stats != null)
				{
                    stats.Damage(5);
                    col.attachedRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
				}
			}
		}
    }
}
