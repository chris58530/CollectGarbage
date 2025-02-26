using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;


public class PlayerShootController : Controller
{
    [SerializeField] private Material gunMaterial;
    [SerializeField] private WorldCanvas worldCanvas;
    [SerializeField] private LayerMask groundLayer;
    private int currentAmmo;
    private float power;
    [SerializeField] private Gun gun;

    protected override void Start()
    {
        base.Start();

        UpdateGunColor();
    }

    protected override void Update()
    {
        base.Update();
        EnterCar();


        if (Input.GetKey(KeyCode.K) || Input.GetMouseButton(0))
        {
            Charge();
            RotateTowardsMouse();
        }
        if (Input.GetKeyUp(KeyCode.K) || Input.GetMouseButtonUp(0))
        {
            Shoot();
            RotateTowardsMouse();
            power = 0;
        }


    }
    public void Charge()
    {
        power += Time.deltaTime * 1.5f;
        worldCanvas.SetText("Power: " + power.ToString("F2"));
    }



    void Shoot()
    {
        if (power <= 1) power = 1;
        gun.Shoot((int)power);
        worldCanvas.SetText($"Shoot {(int)power}", 1);
    }



    void UpdateGunColor()
    {
        if (currentAmmo > 0)
        {
            gunMaterial.color = Color.white;
        }
        else
        {
            gunMaterial.color = Color.red;
        }
    }

    private void EnterCar()
    {
        if (!Input.GetKeyDown(KeyCode.Q)) return;
        PlayerControlSystem.Instance.RequestFlipControl();
    }

    void RotateTowardsMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = transform.position.y;

            Vector3 direction = targetPosition - transform.position;
            if (direction.magnitude > 0.1f) // 避免零向量導致旋轉問題
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;
            }
        }
    }
}
