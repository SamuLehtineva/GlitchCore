using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GC.GlitchCoreProject
{
    public class UIBar : MonoBehaviour
    {
        public static UIBar instance;
        public Image mask;

        private float defaultWidth;

		private void Awake()
		{
            instance = this;
		}

		void Start()
        {
            defaultWidth = mask.rectTransform.rect.width;
        }

        public void SetValue(float value)
		{
            mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, defaultWidth * value);
		}
    }
}
