using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class ViewModelCam : MonoBehaviour
    {
        public Camera mainCam;
        Camera cam;

        void Start()
        {
            cam = GetComponent<Camera>();
            cam.depth = mainCam.depth - 1;
        }
    }
}
