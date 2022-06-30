using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class BulletDecals : MonoBehaviour
    {
        public int maxActiveDecals;
        public GameObject[] decals;
        public List<GameObject> activeDecals;

		private void Awake()
		{
            activeDecals = new List<GameObject>();
		}

		// Update is called once per frame
		void Update()
        {
            if (activeDecals.Count > maxActiveDecals)
			{
                Destroy(activeDecals[0]);
                activeDecals.RemoveAt(0);
			}
        }

        public void CreateDecal(RaycastHit hit, int decal)
		{
            GameObject obj = Instantiate(decals[decal], hit.point, Quaternion.LookRotation(hit.normal));
            obj.transform.position += obj.transform.forward / 1000f;
            activeDecals.Add(obj);
		}
    }
}
