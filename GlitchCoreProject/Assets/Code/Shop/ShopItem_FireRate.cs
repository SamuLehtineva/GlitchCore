using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class ShopItem_FireRate : MonoBehaviour, IShopItem
    {
        [field:SerializeField]
        public string itemName
        {
            get;
            set;
        }

        [field:SerializeField]
        public int price
        {
            get;
            set;
        }

        [field:SerializeField]
        public string itemDesc
        {
            get;
            set;
        }

        public void Buy()
        {
            PlayerStats.instance.fireDelayMod += 0.25f;
        }
    }
}
