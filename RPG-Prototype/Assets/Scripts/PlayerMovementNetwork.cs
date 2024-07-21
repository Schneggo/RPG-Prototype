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
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.81f;

    [Header("Mouse")]
    [SerializeField] private float sensX = 5f;
    [SerializeField] private float sensY = 5f;

    private float xRotation;
    private float yRotation;

    public override void OnNetworkSpawn()
    {
        input = new PlayerInputActions();
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();

        input.Player.Enable();

        input.Player.Jump.performed += Jump;
    }

    private void Update()
    {
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump");
    }
}