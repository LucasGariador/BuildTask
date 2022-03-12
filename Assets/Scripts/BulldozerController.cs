using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulldozerController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;
    private bool isBreaking;

    [SerializeField] private float motorForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMovement();
    }


    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        horizontalInput = verticalInput < 0f ? -horizontalInput : horizontalInput ;
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }


    private void HandleMovement()
    {
        rb.velocity = transform.forward * verticalInput * motorForce;
        transform.Rotate(new Vector3(0f, horizontalInput, 0f));
        if (isBreaking)
        {
            rb.velocity = Vector3.zero;
        }
    }

}
