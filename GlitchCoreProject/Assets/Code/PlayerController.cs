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

        [Header("Slope handling")]
        public float maxSlopeAngle;
        private RaycastHit slopeHit;
        private bool exitingSlope;

        [Header("Dash")]
        public float dashSpeed;
        public float dashDuration;
        public float dashCooldown = 1.5f;
        private float dashTimer;
        private Vector3 dashDirection;

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
            DashMove();
        }

        void ReadInput()
        {
            moveInput = playerInput.Player.Move.ReadValue<Vector2>();
        }

        void MovePlayer()
        {
            moveDirection = orientation.forward * moveInput.y + orientation.right * moveInput.x;

            if (OnSlope())
			{
                
                rigid.AddForce(GetSlopeMoveDirection() * moveSpeed * 10f, ForceMode.Force);
                
                if (!exitingSlope)
				{
                    if (GetSlopeMoveDirection().y < 0.1f)
					{
                        rigid.AddForce(Vector3.down * 80f, ForceMode.Force);
                    }
                    
                    if (rigid.velocity.y < 0f && GetSlopeMoveDirection().y > -0.1f)
					{
                        rigid.velocity = new Vector3(rigid.velocity.x, 0f, rigid.velocity.z);
					}
				}
			}

            if (isGrounded)
			{
                rigid.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            }
            else
			{
                rigid.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            }

            //rigid.useGravity = !OnSlope();
        }

        void Jump(InputAction.CallbackContext context)
        {
            exitingSlope = true;
            if (canJump && isGrounded)
			{
                rigid.velocity = new Vector3(rigid.velocity.x, jumpSpeed, rigid.velocity.z);
                canJump = false;
                Invoke(nameof(ResetJump), jumpCooldown);
            }
            else if (canDoubleJump)
			{
                rigid.velocity = new Vector3(rigid.velocity.x, jumpSpeed * 0.85f, rigid.velocity.z);
                canDoubleJump = false;
                Invoke(nameof(ResetJump), jumpCooldown);
            }
        }

        void ResetJump()
		{
            canJump = true;
            exitingSlope = false;
		}

        void ResetDoubleJump()
		{
            canDoubleJump = true;
		}

        void SpeedControl()
		{
            if (OnSlope() && !exitingSlope)
			{
                if (rigid.velocity.magnitude > moveSpeed)
				{
                    rigid.velocity = rigid.velocity.normalized * moveSpeed;
				}
			}
			else
			{
                Vector3 flatVel = new Vector3(rigid.velocity.x, 0f, rigid.velocity.z);

                if (flatVel.magnitude > moveSpeed)
                {
                    Vector3 limitedVel = flatVel.normalized * moveSpeed;
                    rigid.velocity = new Vector3(limitedVel.x, rigid.velocity.y, limitedVel.z);
                }
            }
		}

        private bool OnSlope()
		{
            if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
			{
                float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
                return angle < maxSlopeAngle && (angle > 5 || angle < -5);
			}

            return false;
		}

        private Vector3 GetSlopeMoveDirection()
		{
            return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
		}

        void StartDash(InputAction.CallbackContext context)
		{
            dashDirection = moveDirection;
            dashTimer = 0f;
        }

        void DashMove()
		{
            if (dashTimer < dashDuration)
			{
                rigid.AddForce(dashDirection.normalized * dashSpeed * 10f, ForceMode.Force);
                rigid.velocity = new Vector3(rigid.velocity.x, 0, rigid.velocity.y);
                dashTimer += Time.fixedDeltaTime;
            }
		}

        private void OnDisable()
        {
            playerInput.Player.Move.Disable();

            playerInput.Player.Jump.Disable();
            playerInput.Player.Jump.performed -= Jump;

            playerInput.Player.Dash.Disable();
            playerInput.Player.Dash.performed -= StartDash;
        }

        private void OnEnable()
        {
            playerInput.Player.Move.Enable();

            playerInput.Player.Jump.performed += Jump;
            playerInput.Player.Jump.Enable();

            playerInput.Player.Dash.Enable();
            playerInput.Player.Dash.performed += StartDash;
        }
        
    }
}

