using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;


public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Material gunMaterial;
    [SerializeField] private float fireCooldown = 0.5f;
    [SerializeField] private int maxAmmo = 3;
    [SerializeField] private float reloadTime = 2f;
    [SerializeField] private WorldCanvas worldCanvas;
     [SerializeField] private LayerMask groundLayer;
    private int currentAmmo;
    private float nextFireTime;
    private bool isReloading;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateGunColor();
    }

    void Update()
    {

        if (isReloading) return;

        if (Input.GetKeyDown(KeyCode.K) || Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
        RotateTowardsMouse();
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.L) || Input.GetMouseButton(1) && currentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        if (currentAmmo > 0)
        {
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            currentAmmo--;
            nextFireTime = Time.time + fireCooldown;
            UpdateGunColor();
        }
        else
        {
            Debug.Log("Out of ammo! Press L to reload.");
        }
    }

    IEnumerator Reload()
    {
        if (currentAmmo > 0) yield break;
        isReloading = true;
        worldCanvas.SetText("Reloading...", reloadTime);
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        UpdateGunColor();
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
