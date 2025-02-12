using UnityEngine;

public class PlayerController : Controller
{
    public float interactRange = 2f;
    public float detectRadius = 3f;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectRadius);
        foreach (var collider in hitColliders)
        {
            Resource resource = collider.GetComponent<Resource>();
            if (resource != null)
            {
                resource.Collect();
                break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}