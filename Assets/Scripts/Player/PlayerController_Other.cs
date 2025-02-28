using UnityEngine;
using UniRx;
using System;

public class PlayerController_Other : Controller
{


    private IDisposable attackDisposable;
    public float interactRange = 2f;
    public float detectRadius = 3f;

    protected override void Start()
    {
        base.Start();

    }

    protected override void Update()
    {
        base.Update();
        EnterCar();
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            
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
 
    private void EnterCar()
    {
        if (!Input.GetKeyDown(KeyCode.Q)) return;
        PlayerControlSystem.Instance.RequestFlipControl();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}