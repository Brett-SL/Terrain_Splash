using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputAction moveDirection;
    [SerializeField] private InputAction turnDirection;
    [SerializeField] private InputAction jump;
    [SerializeField] private InputAction run;

    [SerializeField] private float speed;
    [SerializeField] private float rotateFactor;
    [SerializeField] private float jumpHeight = 0.5f;

    private Rigidbody rb; 

    private void OnEnable()
    {
        moveDirection.Enable();
        turnDirection.Enable();
        jump.Enable();
        run.Enable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ProcessMovement(speed);
        ProcessRotation(rotateFactor);
    }

    private void ProcessRotation(float rotatePerFrame)
    {
        float rotation = turnDirection.ReadValue<float>();

        if (rotation > 0)
        {
            transform.Rotate(0f, 1f * rotatePerFrame * Time.fixedDeltaTime, 0f);
        }
        else if (rotation < 0)
        {
            transform.Rotate(0f, -1f * rotatePerFrame * Time.fixedDeltaTime, 0f);
        }
    }

    private void ProcessMovement(float speedThisFrame)
    {
        float moveInput = moveDirection.ReadValue<float>();
        // float strafeInput = turnDirection.ReadValue<float>();
        
        float runSpeed = speedThisFrame * 1.5f;

        // Up/Down Direction
        if (moveInput > 0)
        {
            transform.Translate(0f, 0f, 1f * speedThisFrame * Time.fixedDeltaTime);
        }
        else if (moveInput < 0)
        {
            transform.Translate(0f, 0f, -1f * speedThisFrame * Time.fixedDeltaTime);
        }

        if (jump.IsPressed())
        {
            Debug.Log($"{jump}");
            transform.Translate(0f, jumpHeight * Time.fixedDeltaTime, 0f);
        }

        if (run.IsPressed() && moveInput > 0)
        {
            Debug.Log($"{run}");
            transform.Translate(0f, 0f, runSpeed * Time.fixedDeltaTime);
        }
        // Left/Right Direction
        /*if (strafeInput > 0)
        {
            transform.Translate(1f * speedThisFrame * Time.fixedDeltaTime, 0, 0);
            Debug.Log($"turning: {strafeInput}");
        }
        else if (strafeInput < 0)
        {
            transform.Translate(-1f * speedThisFrame * Time.fixedDeltaTime, 0, 0);
            Debug.Log($"turning: {strafeInput}");
        }*/
    }
}
