using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public interface IShopItem
    {
        string name
        {
            get;
            set;
        }
        
        void Buy();
    }
}
