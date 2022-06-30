using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GC.GlitchCoreProject
{
    public class Gun2 : MonoBehaviour
    {
        public Transform orientation;
        public float fireDelay;
        public GameObject impactVfx;
        public InputManager inputManager;

        private PlayerInput playerInput;
        private float fireTimer = 0.0f;
        private RaycastHit hit;
        
        void FixedUpdate()
		{
            if (fireTimer < fireDelay)
			{
                fireTimer += 1.0f;
			}
		}

        void Fire1(InputAction.CallbackContext context)
		{
            if (fireTimer >= fireDelay)
			{
                Debug.DrawLine(transform.position, orientation.forward * 50, Color.black, 5f);
                if (Physics.Raycast(transform.position, orientation.forward, out hit, 50f))
				{
                    Instantiate(impactVfx, hit.point, transform.rotation);
                    GameObject.Find("Managers/DecalManager").GetComponent<BulletDecals>().CreateDecal(hit, 0);
                    Debug.Log(hit.rigidbody);
				}
                fireTimer = 0f;
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
