using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class KillTimer : MonoBehaviour
    {
        public float lifeTime;

        float timer = 0.0f;

        // Update is called once per frame
        void FixedUpdate()
        {
            timer += Time.fixedDeltaTime;
            if (timer >= lifeTime)
			{
                Destroy(gameObject);
			}
        }
    }
}
