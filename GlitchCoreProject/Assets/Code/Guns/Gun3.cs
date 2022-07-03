using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GC.GlitchCoreProject
{
    public class Gun3 : MonoBehaviour
    {
        public GameObject bullet;
        public float fireDelay = 50f;
        public PlayerLook playerLook;
        public Transform spawnPos;
        public InputManager inputManager;

        private float fireTimer = 0.0f;
        private PlayerInput playerInput;

		void FixedUpdate()
		{
			if (fireTimer < fireDelay)
			{
                fireTimer += 1.0f;
			}
		}

		public void Fire1(InputAction.CallbackContext context)
		{
            if (fireTimer >= fireDelay)
			{
                Transform orientation = playerLook.transform;
                GameObject current = Instantiate(bullet, spawnPos.position, orientation.rotation);
                if (playerLook.GetTarget() != Vector3.zero)
                {
                    current.transform.LookAt(playerLook.GetTarget());
                }
            }
		}

        private void OnEnable()
        {
            Debug.Log("OnEnable");
            playerInput = inputManager.playerInput;

            playerInput.Player.Fire1.Enable();
            playerInput.Player.Fire1.performed += Fire1;
        }

        private void OnDisable()
        {
            playerInput.Player.Fire1.Disable();
            playerInput.Player.Fire1.performed -= Fire1;
        }
    }
}
