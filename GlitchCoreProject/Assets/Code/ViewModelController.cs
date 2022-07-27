using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class ViewModelController : MonoBehaviour
    {
        public static ViewModelController instance;
        public GameObject[] models;
        public GunManager gunManager;

        int currentModelIndex = 0;
        GameObject currentModelObj;
        Animator anim;

        void Awake()
        {
            instance = this;
        }
        
        void Start()
        {
            currentModelIndex = 0;
            currentModelObj = models[currentModelIndex];
            currentModelObj.SetActive(true);
            anim = GetComponentInChildren<Animator>();
        }

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
                anim = GetComponentInChildren<Animator>();
			}
		}

        public void PlayFireAnim()
        {
            anim.SetTrigger("Shoot");
        }
    }
}
