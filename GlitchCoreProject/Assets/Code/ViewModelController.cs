using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class ViewModelController : MonoBehaviour
    {
        public GameObject[] models;
        public GunManager gunManager;

        int currentModelIndex = 0;
        GameObject currentModelObj;

        void Start()
        {
            currentModelIndex = 0;
            currentModelObj = models[currentModelIndex];
            currentModelObj.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            ChangeModel();
        }

        void ChangeModel()
		{
            if (currentModelIndex != gunManager.currentGun)
			{
                currentModelObj.SetActive(false);
                currentModelIndex = gunManager.currentGun;
                currentModelObj = models[currentModelIndex];
                currentModelObj.SetActive(true);
			}
		}
    }
}
