using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMapTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           MapSystem.Instance.SpawnChunk();
           MapSystem.Instance.RemoveOldChunk();
        }
    }
}
