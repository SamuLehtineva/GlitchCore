using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GC.GlitchCoreProject
{
    public class InputManager : MonoBehaviour
    {
        public PlayerInput playerInput;
        public PlayerInput.PlayerActions playerActions;
        public PlayerInput.HUDActions hudActions;
       
        void Awake()
		{
            playerInput = new PlayerInput();
            playerActions = playerInput.Player;
            hudActions = playerInput.HUD;
		}

		private void OnEnable()
		{
            playerActions.Enable();
            hudActions.Enable();
		}

		private void OnDisable()
		{
            playerActions.Disable();
            hudActions.Disable();
		}
	}
}
