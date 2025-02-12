using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float gravity = -9.81f;
    protected CharacterController characterController;
    protected Vector3 moveDirection;
    protected float verticalVelocity;
    public Transform cameraTransform;

    protected virtual void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    protected virtual void Update()
    {
        MovePlayer();
    }

    protected void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;
        
        if (inputDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            Quaternion toRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDirection = moveDir * moveSpeed;
        }
        else
        {
            moveDirection = Vector3.zero;
        }
        
        if (characterController.isGrounded)
        {
            verticalVelocity = -2f;
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(2f * -gravity);
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        
        moveDirection.y = verticalVelocity;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
