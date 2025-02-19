using UnityEngine;

public class DamageableObject : MonoBehaviour, IDamageable
{
    public void GetHurt()
    {
        transform.Rotate(180, 0, 0);
    }

}