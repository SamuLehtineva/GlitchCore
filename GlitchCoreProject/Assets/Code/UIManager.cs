using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GC.GlitchCoreProject
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;
        [Header("Player Stats")]
        public TMP_Text healthTxt;

        [Header("Interaction")]
        public GameObject itemText;
        public TMP_Text nameTxt;
        public TMP_Text priceTxt;
        public TMP_Text descTxt;
        public IShopItem item;

        [Header("Waves")]
        public TMP_Text waveTxt;
        public TMP_Text timerTxt;

        void Awake()
        {
            instance = this;
        }

        void FixedUpdate()
        {
            if (item != null)
            {
                nameTxt.text = item.itemName;
                priceTxt.text = "Price: " + item.price;
                descTxt.text = item.itemDesc;
            }
        }

        public void ToggleItemInfo(bool value)
        {
            itemText.SetActive(value);
        }
    }
}
