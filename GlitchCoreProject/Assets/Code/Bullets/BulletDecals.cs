using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class BulletDecals : MonoBehaviour
    {
        public GameObject[] decals;
        
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void CreateDecal(RaycastHit hit, int decal)
		{
            GameObject obj = Instantiate(decals[decal], hit.point, Quaternion.LookRotation(hit.normal));
            obj.transform.position += obj.transform.forward / 1000f;
		}
    }
}
