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
        private IShopItem item;

        void Start()
        {
            playerInput = inputManager.playerInput;

            playerInput.Player.Interact.Enable();
            playerInput.Player.Interact.performed += Interact;
        }

        void FixedUpdate()
        {
            CheckForInteraction();
        }

        void CheckForInteraction()
        {
            
            if (Physics.Raycast(transform.position, orientation.forward, out hit, range, ~13))
            {
                Debug.Log("item");
                item = hit.transform.gameObject.GetComponent<IShopItem>();
                if (item != null)
                {
                    UIManager.instance.ToggleItemInfo(true);
                } 
            }
            else
            {
                UIManager.instance.ToggleItemInfo(false);  
            }
        }

        void Interact(InputAction.CallbackContext context)
        {
            if (Physics.Raycast(transform.position, orientation.forward, out hit, range))
            {
                if (hit.transform.gameObject.layer == 13)
                {
                    Debug.Log("shop");
                    item = hit.transform.gameObject.GetComponent<IShopItem>();
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
