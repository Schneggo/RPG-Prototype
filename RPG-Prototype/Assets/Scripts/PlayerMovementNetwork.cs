using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementNetwork : NetworkBehaviour
{
    public PlayerInputActions input;
    private PlayerInput playerInput;
    private CharacterController controller;

    [SerializeField] private Transform playerBody;

    [Header("Stats")]
    [SerializeField] private Vector3 playerVelocity;
    [SerializeField] private float moveSpeed = 4.5f;
    [SerializeField] private float runSpeed = 7f;
    [SerializeField] private float jumpHeight = 1f;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private bool isSprinting = false;

    [Header("Mouse")]
    [SerializeField] private float sensX = 5f;
    [SerializeField] private float sensY = 5f;

    [SerializeField] private Camera cam;

    private float xRotation;
    private float yRotation;

    public override void OnNetworkSpawn()
    {
        input = new PlayerInputActions();
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();

        input.Player.Enable();

        input.Player.Jump.performed += Jump;
        input.Player.SprintingStart.performed += SprintStart;
        input.Player.SprintingFinish.performed += SprintFinish;
    }

    private void SprintStart(InputAction.CallbackContext obj)
    {
        isSprinting = true;
    }

    private void SprintFinish(InputAction.CallbackContext obj)
    {
        isSprinting = false;
    }

    private void Update()
    {
        if (!IsOwner) return;

        if (!isSprinting)
        {
            Movement();
        }
        else
        {
            Sprinting();
        }

        MouseLook();
    }

    private void Movement()
    {
        Vector2 movement = input.Player.Movement.ReadValue<Vector2>();
        var move = transform.right * movement.x + transform.forward * movement.y;
        controller.Move(move * moveSpeed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (!IsOwner) return;

        if (controller.isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void MouseLook()
    {
        Vector2 mouse = input.Player.Mouse.ReadValue<Vector2>();

        var mouseX = mouse.x * sensX * Time.deltaTime;
        var mouseY = mouse.y * sensY * Time.deltaTime;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void Sprinting()
    {
        Vector2 movement = input.Player.Movement.ReadValue<Vector2>();
        var move = transform.right * movement.x + transform.forward * movement.y;
        controller.Move(move * runSpeed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);
    }
}