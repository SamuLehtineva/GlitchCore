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
        private int itemLayer;

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
            if (Physics.Raycast(transform.position, orientation.forward, out hit, range, LayerMask.GetMask("ShopItem", "ShopItem2")))
            {
                item = hit.transform.gameObject.GetComponent<IShopItem>();
                itemLayer = hit.transform.gameObject.layer;
                if (item != null)
                {
                    UIManager.instance.item = item;
                    UIManager.instance.ToggleItemInfo(true);
                } 
            }
            else
            {
                UIManager.instance.ToggleItemInfo(false);
                item = null;
            }
        }

        void Interact(InputAction.CallbackContext context)
        {
            if (item != null)
            {
                if (PlayerStats.instance.money >= item.price)
                {
                    item.Buy();
                    PlayerStats.instance.money -= item.price;
                    if (itemLayer == 13)
                    {
                        ShopController.instance.GetItem1();
                    }
                    else if (itemLayer == 14)
                    {
                        ShopController.instance.GetItem2();
                    }
                    ShopController.instance.Randomize();
                }
            }
            /*if (Physics.Raycast(transform.position, orientation.forward, out hit, range))
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
            }*/
        }

        void OnDisable()
        {
            playerInput.Player.Interact.Disable();
            playerInput.Player.Interact.performed -= Interact;
        }
    }
}
