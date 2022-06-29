using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GC.GlitchCoreProject
{
    public class PlayerLook : MonoBehaviour
    {
        public Transform player;

        public float sensX = 100f;

        public float sensY = 100f;

        private float mouseX;

        private float mouseY;

        private float xRotation;

        private float yRotation;

        private Vector2 lookDirection;

        private PlayerInput playerLook;

        void Awake()
        {
            playerLook = new PlayerInput();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            Look();
        }

        private void OnDisable()
        {
            playerLook.Player.Look.Disable();
        }

        private void OnEnable()
        {
            playerLook.Player.Look.Enable();
        }

        public void Look()
        {
            lookDirection = playerLook.Player.Look.ReadValue<Vector2>();

            mouseX = lookDirection.x * Time.fixedDeltaTime * sensX;
            mouseY = lookDirection.y * Time.fixedDeltaTime * sensY;

            xRotation -= mouseY;
            yRotation += mouseX;

            xRotation = Mathf.Clamp(xRotation, -90f, 90);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            player.rotation = Quaternion.Euler(0, yRotation, 0);

            /*mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            transform.rotation = Quaternion.Euler(0, yRotation, 0);*/
        }

        public Vector3 GetTarget()
		{
            RaycastHit hit;
            int layerMask = (1 << 3) | (1 << 7);
            Physics.Raycast(transform.position, transform.forward, out hit, 100f, ~layerMask);
            return hit.point;
		}
    }
}