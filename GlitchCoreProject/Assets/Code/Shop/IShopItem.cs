using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public interface IShopItem
    {
        string itemName
        {
            get;
            set;
        }

        int price
        {
            get;
            set;
        }

        string itemDesc
        {
            get;
            set;
        }
        
        void Buy();
    }
}
