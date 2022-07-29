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
        int layerMask = (1 << 12) | (1 << 11);

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
            if (Physics.Raycast(transform.position, transform.forward, out hit, 0.2f, ~layerMask))
			{
                Debug.Log(hit.transform.gameObject.layer);
                EffectManager.instance.SpawnEffect(0, transform.position, transform.rotation);
                PlayerStats stats = hit.collider.gameObject.GetComponent<PlayerStats>();
                if (stats != null)
				{
                    Debug.Log("kkkkkk");
                    stats.Damage(25);
				}
                else if (hit.collider.gameObject.layer == 6)
				{
                    DecalManager.instance.CreateDecal(hit, 0);
				}
                Destroy(gameObject);
            }
		}

        void OnCollisionEnter(Collision other)
        {
            Debug.Log(other.gameObject.layer);
            if (other.gameObject.layer != 11)
            {
                EffectManager.instance.SpawnEffect(0, transform.position, transform.rotation);
            PlayerStats stats = other.collider.gameObject.GetComponent<PlayerStats>();
            if (stats != null)
			{
                Debug.Log("kmshsdfh");
                stats.Damage(25);
			}
            Destroy(gameObject);
            }
            
        }
    }
}
