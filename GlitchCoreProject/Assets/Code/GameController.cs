using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class GameController : MonoBehaviour
    {
		public bool lockFps;
		public bool vSync;

		private void Awake()
		{
			if (vSync)
			{
				QualitySettings.vSyncCount = 1;
			}
			else
			{
				QualitySettings.vSyncCount = 0;
			}
			
			if (lockFps)
			{
				Application.targetFrameRate = 60;
			}
			else
			{
				Application.targetFrameRate = -1;
			}
		}

		private void Update()
		{
			
		}
	}
}
