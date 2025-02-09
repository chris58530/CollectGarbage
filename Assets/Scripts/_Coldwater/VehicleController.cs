using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public float maxSpeed = 20.0f;
    public float acceleration = 5.0f;
    public float deceleration = 5.0f;
    public float turnSpeed = 5.0f;
    private float currentSpeed = 0.0f;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("CharacterController component is missing from this game object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController == null) return;

        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Handle acceleration and deceleration
        if (moveInput > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (moveInput < 0)
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, deceleration * Time.deltaTime);
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        // Handle movement
        if (Mathf.Abs(moveInput) > 0)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            characterController.Move(forward * currentSpeed * Time.deltaTime);
        }

        // Handle turning
        float turn = turnInput * turnSpeed * Time.deltaTime;
        transform.Rotate(0, turn, 0);
    }
}
