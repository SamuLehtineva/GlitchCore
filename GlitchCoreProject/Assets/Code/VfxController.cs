using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace GC.GlitchCoreProject
{
    public class VfxController : MonoBehaviour
    {
        public float duration;
        VisualEffect vfx;

        void Start()
        {
            vfx = GetComponent<VisualEffect>();
            vfx.Play();
            StartCoroutine(EndDelay());
        }

        IEnumerator EndDelay()
		{
            yield return new WaitForSeconds(duration);
            Destroy(this.gameObject);
		}
    }
}
