using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBehaviour : MonoBehaviour
{
    private PlayerInput input;

    [Header("Player Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintMultiplier;
    [SerializeField] private float gravity = -9.81f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float groundDistance;

    private CharacterController characterController;

    private Vector3 playerVelocity;
    private float moveMultiplier = 1;
    public bool isGrounded { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        input = PlayerInput.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        MovePlayer();
    }

    void MovePlayer() {
        moveMultiplier = input.sprint ? sprintMultiplier : 1;

        characterController.Move((transform.forward * input.vertical + transform.right * input.horizontal) * moveSpeed * Time.deltaTime * moveMultiplier);

        // Ground Check
        if (isGrounded && playerVelocity.y < 0) {
            playerVelocity.y = -2f;
        }

        playerVelocity.y += gravity * Time.deltaTime;

        characterController.Move(playerVelocity * Time.deltaTime);
    }

    void GroundCheck() {
        // check if grounded using raycast
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);
    }

    public void SetYVelocity(float value) {
        playerVelocity.y = value;
    }

    public float GetForwardSpeed() {
        return input.vertical * moveSpeed * moveMultiplier;
    }
}
