using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;


public class AttackWeapon : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<IDamageable>(out var damageObj)) return;
        //Enemy layer

        damageObj.GetHurt();
        // //Damage frist then use attackActions effect attack
        // Vector3 thisPosition = transform.position;
        // Vector3 collisionPoint = other.ClosestPoint(thisPosition);

        // Quaternion rotation = Quaternion.LookRotation(thisPosition-collisionPoint);
        // damageObj.OnTakeDamage(attackValue, collisionPoint, rotation);
        // //Damage frist then use attackActions effect attack (ability)
        // attackAction?.Invoke(other);


        // // Debug.Log("主角攻擊了" + other.name + " 造成了" + attackValue + "傷害");

        // PlayerActions.onHitEnemy?.Invoke();

        // //計算接觸點 觸發特效
        // //手把震動
        // SystemActions.onGamePadVibrate?.Invoke(low, high, time);
    }


}