using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class ShopController : MonoBehaviour
    {
        public Transform itemPos1;
        public Transform itemPos2;
        public List<IShopItem> items;

        private IShopItem item1;
        private IShopItem item2;

        void Randomize()
        {
            item1 = items[(int)Random.Range(0, items.Count)];
        }
    }
}
