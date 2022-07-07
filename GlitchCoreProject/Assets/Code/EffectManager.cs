using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class EffectManager : MonoBehaviour
    {
        public static EffectManager instance;
        public GameObject[] effects;

		private void Awake()
		{
            instance = this;
		}

		public void SpawnEffect(int effect, Vector3 position, Quaternion rotation)
		{
			Instantiate(effects[effect], position, rotation);
		}
    }
}
