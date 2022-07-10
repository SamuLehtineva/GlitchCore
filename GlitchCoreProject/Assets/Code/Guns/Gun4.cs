using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GC.GlitchCoreProject
{
    public class Gun4 : MonoBehaviour
    {
        public Transform orientation;
        public float fireDelay;
        public InputManager inputManager;

        private PlayerInput playerInput;
        private float fireTimer = 0.0f;

		private void FixedUpdate()
		{
			if (fireTimer < fireDelay)
			{
				fireTimer += 1.0f;
			}
		}

        void Fire1 (InputAction.CallbackContext context)
		{
            if (fireTimer >= fireDelay)
			{

			}
		}

        private void OnEnable()
        {
            playerInput = inputManager.playerInput;

            playerInput.Player.Fire1.Enable();
            playerInput.Player.Fire1.performed += Fire1;
            fireTimer = fireDelay * 0.75f;
        }

        private void OnDisable()
        {
            playerInput.Player.Fire1.Disable();
            playerInput.Player.Fire1.performed -= Fire1;
        }
    }
}
