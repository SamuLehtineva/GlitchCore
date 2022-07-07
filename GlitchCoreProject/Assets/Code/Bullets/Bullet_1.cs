using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class Bullet_1 : MonoBehaviour
    {
        public float speed;
        public float lifeTime;
        public GameObject impact;

        float timer = 0.0f;
        int layerMask = (1 << 7) | (1 << 3);
        
        void Update()
        {
            timer += Time.deltaTime;
            transform.position += transform.forward * speed * Time.deltaTime;
            CheckHit();

            if (timer > lifeTime)
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
                Destroy(this.gameObject);
            }
		}
	}
}
