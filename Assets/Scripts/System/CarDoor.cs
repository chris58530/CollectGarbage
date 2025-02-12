using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDoor : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CarSystem.Instance.RequestChangePlayControl();
        }
    }
}
