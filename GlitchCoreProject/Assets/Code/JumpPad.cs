using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class JumpPad : MonoBehaviour
    {
        public float power;
        public float coolDown;

        private float timer = 0.0f;

        void Update()
        {
            if (timer < coolDown)
            {
                timer += Time.deltaTime;
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerStats>() != null)
            {
                Debug.Log("pad");
                if (timer >= coolDown)
                {
                    other.GetComponent<Rigidbody>().AddForce(0, power, 0, ForceMode.Impulse);
                    timer = 0f;
                }
            }    
        }
    }
}
