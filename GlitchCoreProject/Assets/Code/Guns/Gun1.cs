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
		public float fireDelay = 6f;

		private float fireTimer = 0.0f;
		private bool tryFire1;
		PlayerInput playerInput;
		//private PlayerInput.PlayerActions playerActions;
        
        void Awake()
		{
			playerInput = new PlayerInput();
			//playerActions = GameObject.Find("InputManager").GetComponent<InputManager>().playerActions;
		}

		private void Update()
		{
			if (tryFire1)
			{
				AttemptFire();
			}
		}

		private void FixedUpdate()
		{
			if (fireTimer < fireDelay)
			{
				fireTimer += 1f;
			}
		}

		void AttemptFire()
		{
			if (fireTimer >= fireDelay)
			{
				Fire();
				fireTimer = 0;
			}
		}

		void Fire()
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
			playerInput.Player.Fire2.Enable();

			playerInput.Player.Fire1.performed += _ => tryFire1 = true;
			playerInput.Player.Fire1.canceled += _ => tryFire1 = false;
			playerInput.Player.Fire2.performed += Fire2;
		}

		private void OnDisable()
		{
			playerInput.Player.Fire1.Disable();
			playerInput.Player.Fire2.Disable();

			playerInput.Player.Fire1.performed -= _ => tryFire1 = true;
			playerInput.Player.Fire1.canceled -= _ => tryFire1 = false;
			playerInput.Player.Fire2.performed -= Fire2;
		}
	}
}
