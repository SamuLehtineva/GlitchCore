using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class Bullet_2 : MonoBehaviour
    {
        public Vector3 speed;
        public float lifeTime;

        float timer;
        Rigidbody rigid;

        void Start()
        {
            rigid = GetComponent<Rigidbody>();
            rigid.AddRelativeForce(speed, ForceMode.Impulse);
        }

        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= lifeTime)
			{
                Destroy(this.gameObject);
			}
        }
	}
}
