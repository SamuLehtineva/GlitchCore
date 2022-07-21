using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class ShopItem1 : MonoBehaviour, IShopItem
    {
        public string itemName
        {
            get;
            set;
        }

        public int price
        {
            get;
            set;
        }

        public void Buy()
        {
            GunManager.instance.usableGuns.Add(2);
        }
    }
}
