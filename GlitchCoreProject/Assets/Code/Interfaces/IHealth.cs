using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public interface IHealth
    {
        float maxHealth
		{
            get;
            set;
		}

        float currenthealth
		{
            get;
            set;
		}

        void Damage(int amount);
    }
}
