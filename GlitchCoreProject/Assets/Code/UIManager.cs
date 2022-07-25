using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GC.GlitchCoreProject
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;
        public GameObject ItemText;
        public TMP_Text nameTxt;
        public TMP_Text priceTxt;
        public TMP_Text descTxt;
        public IShopItem item;

        void Awake()
        {
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
