using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class GunManager : MonoBehaviour
    {
        public GameObject[] guns;
        public int currentGun = 0;
        public InputManager inputManager;

        private PlayerInput playerInput;
        private float scrollInput;

        void Start()
        {
            playerInput = inputManager.playerInput;
            playerInput.Player.NextWeapon.Enable();
        }

        void Update()
        {
            ReadInput();
            if (scrollInput != 0f)
			{
                Debug.Log(scrollInput);
            }
            
        }

        void ReadInput()
		{
            scrollInput = playerInput.Player.NextWeapon.ReadValue<Vector2>().y;
		}

		private void OnDisable()
		{
            playerInput.Player.NextWeapon.Disable();
		}
	}
}
