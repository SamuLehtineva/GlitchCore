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

        private float fireTimer = 0.0f;
        private PlayerInput.PlayerActions playerActions;

        void Awake()
		{
            playerActions = GameObject.Find("InputManager").GetComponent<InputManager>().playerActions;
        }

        
        void FixedUpdate()
		{
            if (fireTimer < fireDelay)
			{
                fireTimer += 1.0f;
			}
		}

        void Fire1(InputAction.CallbackContext context)
		{

		}

		private void OnEnable()
		{
            playerActions.Fire1.performed += Fire1;
		}
	}
}
