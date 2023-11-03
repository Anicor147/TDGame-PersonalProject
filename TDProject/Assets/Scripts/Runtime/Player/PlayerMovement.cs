using System;
using UnityEngine;

namespace Runtime.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")] 
        public float walkSpeed = 4f;

        [Header("Mouse Look")] 
        public Transform cam;
        public float sensitivity;
        [Header("GravitySet")] 
        public float gravityScale = 1.5f;
    
        private CharacterController characterController;

        private float horizontalInput;
        private float verticalInput;
        private float mouseX;
        private float mouseY;
        private float yVelocity;

        private Vector3 playerInput;
        private Vector3 moveDirection;


        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void LateUpdate()
        {
            GetInput();
            ManipulateController();
            DoMouseLook();
            Gravity();
        }

        void GetInput()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
            playerInput = new Vector3(horizontalInput , 0 ,verticalInput);
            mouseX = Input.GetAxisRaw("Mouse X") * sensitivity;
            mouseY -= Input.GetAxisRaw("Mouse Y") * sensitivity;
            mouseY = Mathf.Clamp(mouseY, -45f, 45f);

        }

        void DoMouseLook()
        { 
            cam.localRotation = Quaternion.Euler(mouseY,0,0);
            transform.Rotate(0,mouseX,0);
        }

        void ManipulateController()
        {
            moveDirection = transform.rotation * playerInput.normalized * walkSpeed ;
            moveDirection.y = yVelocity;
            moveDirection *= Time.deltaTime;
        
            characterController.Move(moveDirection);
        }

        void Gravity()
        {
            yVelocity += Physics.gravity.y * gravityScale * Time.deltaTime;
        }
    }
}
