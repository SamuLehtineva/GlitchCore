using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class ShopController : MonoBehaviour
    {
        public static ShopController instance;
        public Transform itemPos1;
        public Transform itemPos2;
        public List<GameObject> items;

        private GameObject item1;
        private GameObject item2;

        void Awake()
        {
            instance = this;
            Randomize();
        }

        public void Randomize()
        {
            item1 = items[(int)Random.Range(0, items.Count)].transform.gameObject;
            Instantiate(item1, itemPos1.position, itemPos1.rotation);
            items.Remove(item1);

            item2 = items[(int)Random.Range(0, items.Count)].transform.gameObject;
            Instantiate(item2, itemPos2.position, itemPos2.rotation);
            items.Remove(item2);
        }
    }
}
