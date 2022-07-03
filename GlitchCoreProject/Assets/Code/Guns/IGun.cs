using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public interface IGun
    {
        string gunName
		{
            get;
            set;
		}
        
        float fireDelay
		{
            get;
            set;
		}

        void Fire1();
    }
}
