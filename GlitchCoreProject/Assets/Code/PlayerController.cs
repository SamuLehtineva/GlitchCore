using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GC.GlitchCoreProject
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 100f;

        public float jumpSpeed = 8;

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
        }

        void Update()
        {
            ReadInput();
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
            moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;
            rigid.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Acceleration);
        }

        public void Jump(InputAction.CallbackContext context)
        {
            rigid.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);

            if (context.performed)
            {

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

