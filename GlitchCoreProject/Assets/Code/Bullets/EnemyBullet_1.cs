using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class EnemyBullet_1 : MonoBehaviour
    {
        public float speed;
        public float lifeTime;

        float timer = 0.0f;
        int layerMask = 12;

        void Update()
        {
            timer += Time.deltaTime;
            transform.position += transform.forward * speed * Time.deltaTime;
            CheckHit();

            if (timer > lifeTime)
			{
                Destroy(gameObject);
			}
        }

        void CheckHit()
		{
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 0.2f))
			{
                Debug.Log("kmshsdfh");
                EffectManager.instance.SpawnEffect(0, transform.position, transform.rotation);
                PlayerStats stats = hit.collider.gameObject.GetComponent<PlayerStats>();
                if (stats != null)
				{
                    stats.Damage(25);
                    hit.rigidbody.AddForce(transform.forward * 500f);
				}
                else if (hit.collider.gameObject.layer == 6)
				{
                    DecalManager.instance.CreateDecal(hit, 0);
				}
                Destroy(gameObject);
            }
		}
    }
}
