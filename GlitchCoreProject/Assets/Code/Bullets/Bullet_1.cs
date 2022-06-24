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
        
        void Update()
        {
            timer += Time.deltaTime;
            transform.position += transform.forward * speed * Time.deltaTime;

            if (timer > lifeTime)
			{
                Destroy(this.gameObject);
			}
        }

		void OnCollisionEnter(Collision collision)
		{
            Instantiate(impact, transform.position, transform.rotation);
            Destroy(this.gameObject);
		}
	}
}
