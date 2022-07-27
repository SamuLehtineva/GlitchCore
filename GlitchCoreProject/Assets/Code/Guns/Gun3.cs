using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GC.GlitchCoreProject
{
    public class Gun3 : MonoBehaviour
    {
        public GameObject bullet;
        public float baseFireDelay = 50f;
        public PlayerLook playerLook;
        public Transform spawnPos;
        public InputManager inputManager;
        public Transform muzzlePos;

        float fireDelay;
        private float fireTimer = 0.0f;
        private PlayerInput playerInput;

		void FixedUpdate()
		{
            fireDelay = baseFireDelay / PlayerStats.instance.fireDelayMod;
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
                fireTimer = 0.0f;

                if (muzzlePos != null)
                {
                    EffectManager.instance.SpawnEffect(3, muzzlePos.position, transform.rotation);
                }
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
