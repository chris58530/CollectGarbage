using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float gravity = -9.81f;
    public float interactRange = 2f; // 可互動距離

    private CharacterController characterController;
    private Vector3 moveDirection;
    private float verticalVelocity; public float detectRadius = 3f; // 檢測半徑

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 玩家移動
        MovePlayer();

        // 玩家互動
        if (Input.GetKeyDown(KeyCode.E)) // 按下 E 鍵
        {
            Interact();
        }
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

        moveDirection = horizontalMove * moveSpeed;
        moveDirection.y = verticalVelocity;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    void Interact()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectRadius);
        foreach (var collider in hitColliders)
        {
            Resource resource = collider.GetComponent<Resource>();
            if (resource != null)
            {
                resource.Collect(); // 撿取物品
                break; // 一次只撿一個物品
            }
        }
    }
      // 在 Scene 視圖中可視化檢測範圍
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
