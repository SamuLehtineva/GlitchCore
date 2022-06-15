using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GC.GlitchCoreProject
{
    public class Gun1 : MonoBehaviour
    {
        public GameObject bullet;
		public Transform orientation;
        private PlayerInput playerInput;
        
        void Awake()
		{
            playerInput = new PlayerInput();
		}

		void Fire(InputAction.CallbackContext context)
		{
			Instantiate(bullet, transform.position, orientation.rotation);
		}

		private void OnEnable()
		{
			playerInput.Player.Fire1.Enable();
			playerInput.Player.Fire1.performed += Fire;
		}

		private void OnDisable()
		{
			playerInput.Player.Fire1.Disable();
			playerInput.Player.Fire1.performed -= Fire;
		}
	}
}
