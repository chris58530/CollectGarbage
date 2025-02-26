using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootPoint;

    public void Shoot(float damage)
    {
        Bullet bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        bullet.damage = damage;
    }
}
