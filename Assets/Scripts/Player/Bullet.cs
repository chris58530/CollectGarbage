using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    public float damage;
    void Start()
    {
        StartCoroutine(MoveForward());
    }



    IEnumerator MoveForward()
    {
        float duration = 5f; // Duration in seconds
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject); // Destroy the bullet after 5 seconds
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageableObject))
        {
            damageableObject.GetHurt(damage);
            Destroy(gameObject);
        }
    }
}
