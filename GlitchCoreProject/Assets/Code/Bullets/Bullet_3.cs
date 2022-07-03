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
        public GameObject impact;

        float timer = 0.0f;
        int layerMask = 1 << 7;

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
                GameObject.Find("Managers/DecalManager").GetComponent<BulletDecals>().CreateDecal(hit, 0);
                Destroy(this.gameObject);
            }
        }
    }
}
