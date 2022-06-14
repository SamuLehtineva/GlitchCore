using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GC.GlitchCoreProject
{
    public class HudController : MonoBehaviour
    {
        private PlayerInput playerInput;

		void Awake()
		{
            playerInput = new PlayerInput();
		}

		void Start()
        {
        
        }

        void Update()
        {
        
        }

		void Pause(InputAction.CallbackContext context)
		{
			SceneChanger.LoadLevel("Menu");
		}

		void OnEnable()
		{
			playerInput.HUD.Pause.Enable();
			playerInput.HUD.Pause.performed += Pause;
		}

		void OnDisable()
		{
			playerInput.HUD.Pause.Disable();
		}
	}
}
