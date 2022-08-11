using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GC.GlitchCoreProject
{
    public class GameController : MonoBehaviour
    {
		public static GameController instance;
		public bool isPaused;

        private PlayerInput playerInput;

		void Awake()
		{
			instance = this;
			isPaused = false;
            playerInput = new PlayerInput();
		}

		void Pause(InputAction.CallbackContext context)
		{
			TogglePause();
		}

		public void TogglePause()
		{
			/*if (!Application.isEditor)
			{
				SceneChanger.LoadLevelAdditive("PauseMenu");
			}*/
			if (!isPaused)
			{
				isPaused = true;
				Time.timeScale = 0.0f;
				SceneChanger.LoadLevelAdditive("PauseMenu");
				Cursor.lockState = CursorLockMode.Confined;
				Cursor.visible = true;
			}
			else
			{
				isPaused = false;
				Time.timeScale = 1.0f;
				SceneChanger.UnloadLevel("PauseMenu");
				Cursor.lockState = CursorLockMode.Locked;
            	Cursor.visible = false;
			}
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
