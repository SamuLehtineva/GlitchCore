using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GC.GlitchCoreProject
{
    public class PlayerController : MonoBehaviour
    {
        public Transform orientation;

        [Header("Movement")]
        public float moveSpeed = 7f;
        public float groundDrag;
        public float jumpSpeed = 8;
        public float jumpCooldown;
        public float airMultiplier;
        bool canJump;
        bool canDoubleJump;

        [Header("Ground Check")]
        public float playerHeight;
        public LayerMask groundMask;
        bool isGrounded;

        private Vector2 moveInput;
        private Vector3 moveDirection;
        private PlayerInput playerInput;
        private Rigidbody rigid;

        void Awake()
        {
            playerInput = new PlayerInput();
        }

        void Start()
        {
            rigid = GetComponent<Rigidbody>();
            ResetJump();
        }

        void Update()
        {
            ReadInput();
            SpeedControl();

            isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.4f, groundMask);
            if (isGrounded)
			{
                rigid.drag = groundDrag;
                ResetDoubleJump();
			}
            else
			{
                rigid.drag = 0;
			}
            
        }

        void FixedUpdate()
        {
            MovePlayer();
            //player.velocity = moveDirection * speed * Time.fixedDeltaTime;
        }

        void ReadInput()
        {
            moveInput = playerInput.Player.Move.ReadValue<Vector2>();
        }

        void MovePlayer()
        {
            moveDirection = orientation.forward * moveInput.y + orientation.right * moveInput.x;

            if (isGrounded)
			{
                rigid.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            }
            else
			{
                rigid.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            }
        }

        void Jump(InputAction.CallbackContext context)
        {
            Debug.Log("jump");
            if (canJump && isGrounded)
			{
                rigid.velocity = new Vector3(rigid.velocity.x, 0f, rigid.velocity.z);
                rigid.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
                canJump = false;
                Invoke(nameof(ResetJump), jumpCooldown);
            }
            else if (canDoubleJump)
			{
                rigid.velocity = new Vector3(rigid.velocity.x, 0f, rigid.velocity.z);
                rigid.AddForce(transform.up * jumpSpeed * 0.85f, ForceMode.Impulse);
                canDoubleJump = false;
                Invoke(nameof(ResetJump), jumpCooldown);
            }

            if (context.performed)
            {

            }
        }

        void ResetJump()
		{
            canJump = true;
		}

        void ResetDoubleJump()
		{
            canDoubleJump = true;
		}

        void SpeedControl()
		{
            Vector3 flatVel = new Vector3(rigid.velocity.x, 0f, rigid.velocity.z);

            if (flatVel.magnitude > moveSpeed)
			{
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rigid.velocity = new Vector3(limitedVel.x, rigid.velocity.y, limitedVel.z);
			}
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
        
    }
}

