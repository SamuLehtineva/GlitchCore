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
        public GameObject impact;

        float timer = 0.0f;
        int layerMask = (1 << 7) | (1 << 3);

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
                Instantiate(impact, transform.position, transform.rotation);
                DecalManager.instance.CreateDecal(hit, 0);
                Explode();
                Destroy(this.gameObject);
            }
        }

        void Explode()
		{
            Collider[] objectsInRange = Physics.OverlapSphere(transform.position, explosionRadius);

            foreach (Collider col in objectsInRange)
			{
                Rigidbody rigid = col.GetComponent<Rigidbody>();
                if (rigid != null)
				{
                    Debug.Log(rigid);
				}
			}
		}
    }
}
