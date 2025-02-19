using UnityEngine;
using UniRx;
using System;

public class PlayerController_Other : Controller
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject attackCollider;

    private IDisposable attackDisposable;
    public float interactRange = 2f;
    public float detectRadius = 3f;

    protected override void Start()
    {
        base.Start();
        attackCollider.SetActive(false);

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
            Attack();
        }


    }
    public void AnimationAttack()
    {

        attackDisposable?.Dispose();
        attackCollider.SetActive(true);

     
    }
    public void AttackFinish(){
            attackCollider.SetActive(false);

    }
    protected override void Move()
    {
        base.Move();
        if (isMove)
            animator.Play("Walk");


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
    void Attack()
    {
        animator.Play("Attack");
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