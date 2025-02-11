using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class PlayerInCarController : MonoBehaviour
{
    private CharacterController characterController;
    private float verticalVelocity;
    private Vector3 moveDirection;
    public float rotationSpeed = 3f;

    public float moveSpeed = 5f;


    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }
    void Update()
    {
        MovePlayer();


    }
    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 horizontalMove = new Vector3(horizontal, 0f, vertical).normalized;

        if (horizontalMove != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(horizontalMove, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }




        moveDirection = horizontalMove * moveSpeed;
        moveDirection.y = verticalVelocity;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
