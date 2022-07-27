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
        private GameObject current1;
        private GameObject current2;

        void Awake()
        {
            instance = this;
            Randomize();
        }

        public void Randomize()
        {
            if (items.Count > 0)
            {
                item1 = items[(int)Random.Range(0, items.Count)].transform.gameObject;
                current1 = Instantiate(item1, itemPos1.position, itemPos1.rotation);
                current1.layer = 13;
                
                if (items.Count > 1)
                {
                    do
                    {
                        item2 = items[(int)Random.Range(0, items.Count)].transform.gameObject;
                    }
                    while (item2 == item1);
                    current2 = Instantiate(item2, itemPos2.position, itemPos2.rotation);
                    current2.layer = 14;
                }
            }
        }

        public void GetItem1()
        {
            items.Remove(item1);
            CleanUp();
        }

        public void GetItem2()
        {
            items.Remove(item2);
            CleanUp();
        }

        void CleanUp()
        {
            Destroy(current1.gameObject);
            Destroy(current2.gameObject);
        }
    }
}
