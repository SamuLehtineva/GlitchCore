using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    private float mouseX;

    private float mouseY;

    private float xRotation;

    private float yRotation;

    private float mouseSensitivity = 0.1f;

    private Vector2 lookDirection;

    private PlayerInput playerLook;

    Camera mainCamera;

    void Awake()
    {
        playerLook = new PlayerInput();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
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

        mouseX = lookDirection.x * mouseSensitivity;
        mouseY = lookDirection.y * mouseSensitivity;

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
