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

            mouseX = lookDirection.x * sensX;
            mouseY = lookDirection.y * sensY;

            xRotation -= mouseY;
            yRotation += mouseX;

            xRotation = Mathf.Clamp(xRotation, -90f, 90);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            player.rotation = Quaternion.Euler(0, yRotation, 0);

            /*mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            transform.rotation = Quaternion.Euler(0, yRotation, 0);*/
        }
    }
}