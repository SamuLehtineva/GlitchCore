using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GC.GlitchCoreProject
{
    public class InteractionController : MonoBehaviour
    {
        public Transform orientation;
        public float range;
        public InputManager inputManager;

        RaycastHit hit;
        private PlayerInput playerInput;

        void Start()
        {
            playerInput = inputManager.playerInput;

            playerInput.Player.Interact.Enable();
            playerInput.Player.Interact.performed += Interact;
        }

        void Interact(InputAction.CallbackContext context)
        {
            if (Physics.Raycast(transform.position, orientation.forward, out hit, range))
            {
                if (hit.transform.gameObject.layer == 13)
                {
                    IShopItem item = hit.transform.gameObject.GetComponent<IShopItem>();
                    if (item != null)
                    {
                        item.Buy();
                    }
                }
            }
        }

        void OnDisable()
        {
            playerInput.Player.Interact.Disable();
            playerInput.Player.Interact.performed -= Interact;
        }
    }
}
