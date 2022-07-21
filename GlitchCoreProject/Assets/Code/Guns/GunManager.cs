using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class GunManager : MonoBehaviour
    {
        public static GunManager instance;
        public GameObject[] guns;
        public int currentGun = 0;
        public InputManager inputManager;
        public List<int> usableGuns;

        private PlayerInput playerInput;
        private float scrollInput;
        private GameObject currentGunObj;

        void Awake()
        {
            instance = this;
        }
        void Start()
        {
            usableGuns = new List<int>();
            usableGuns.Add(0);
            usableGuns.Add(1);
            usableGuns.Add(2);
            usableGuns.Add(3);
            playerInput = inputManager.playerInput;
            playerInput.Player.NextWeapon.Enable();

            currentGun = 0;
            currentGunObj = guns[0];
            currentGunObj.SetActive(true);
        }

        void Update()
        {
            ReadInput();
            ScrollThroughGuns();
            ChangeGun(currentGun);
        }

        void ReadInput()
		{
            scrollInput = playerInput.Player.NextWeapon.ReadValue<Vector2>().y;
		}

        void ScrollThroughGuns()
		{
            if (scrollInput > 0)
			{
                currentGun++;
                if (currentGun >= guns.Length)
				{
                    currentGun = 0;
				}

                while (!usableGuns.Contains(currentGun))
                {
                    currentGun++;
                    if (currentGun >= guns.Length)
				    {
                        currentGun = 0;
				    }
                }                
			}
            else if (scrollInput < 0)
			{
                currentGun--;
                if (currentGun < 0)
				{
                    currentGun = guns.Length - 1;
				}

                while (!usableGuns.Contains(currentGun))
                {
                    currentGun--;
                    if (currentGun < 0)
				    {
                        currentGun = guns.Length - 1;
				    }
                }
			}
		}

        void ChangeGun(int index)
		{
            if (guns[currentGun] != currentGunObj)
			{
                currentGunObj.SetActive(false);
                currentGunObj = guns[currentGun];
                currentGunObj.SetActive(true);
			}
		}

		private void OnDisable()
		{
            playerInput.Player.NextWeapon.Disable();
		}
	}
}
