using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class RotateTransform : MonoBehaviour
    {
        public float speed;

        void Update()
        {
            transform.Rotate(0f, speed * Time.deltaTime, 0f, Space.Self);
        }
    }
}
