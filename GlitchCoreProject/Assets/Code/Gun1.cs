using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GC.GlitchCoreProject
{
    public class Gun1 : MonoBehaviour
    {
        public GameObject bullet;
		public GameObject bullet2;
		public Transform orientation;
        private PlayerInput playerInput;
        
        void Awake()
		{
            playerInput = new PlayerInput();
		}

		void Fire(InputAction.CallbackContext context)
		{
			Instantiate(bullet, transform.position + orientation.forward * 0.5f, orientation.rotation);
		}

		void Fire2(InputAction.CallbackContext context)
		{
			Instantiate(bullet2, transform.position + orientation.forward * 0.5f, orientation.rotation);
		}

		private void OnEnable()
		{
			playerInput.Player.Fire1.Enable();
			playerInput.Player.Fire1.performed += Fire;

			playerInput.Player.Fire2.Enable();
			playerInput.Player.Fire2.performed += Fire2;
		}

		private void OnDisable()
		{
			playerInput.Player.Fire1.Disable();
			playerInput.Player.Fire1.performed -= Fire;

			playerInput.Player.Fire2.Disable();
			playerInput.Player.Fire2.performed -= Fire2;
		}
	}
}
