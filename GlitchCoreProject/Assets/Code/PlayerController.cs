using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody player;

    public float speed = 100f;

    public float jumpSpeed = 8;

    private Vector2 moveInput;

    private Vector3 moveDirection;

    private PlayerInput playerInput;

    void Awake()
    {
        playerInput = new PlayerInput();
    }

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInput = playerInput.Player.Move.ReadValue<Vector2>();
        moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;
        
    }

	void FixedUpdate()
	{
        //player.AddForce(moveDirection * velocity, ForceMode.Acceleration);
        player.velocity = moveDirection * speed * Time.fixedDeltaTime;
    }

	private void OnDisable()
    {
        playerInput.Player.Move.Disable();
        playerInput.Player.Jump.Disable();
    }

    private void OnEnable()
    {
        playerInput.Player.Move.Enable();

        playerInput.Player.Jump.performed += Jump;
        playerInput.Player.Jump.Enable();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        player.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        
        if (context.performed)
        {
            
        }
    }
}
