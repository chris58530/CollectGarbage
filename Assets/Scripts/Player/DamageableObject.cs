using UnityEngine;

public class DamageableObject : MonoBehaviour, IDamageable
{
    public void GetHurt(float damage)
    {
        transform.Rotate(180, 0, 0);
    }

}