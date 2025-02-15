using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class BehaviorTreeManager : MonoBehaviour
{
    [SerializeField] private SharedGameObject playerTransform; 
    [SerializeField] private SharedGameObject CampervanTransform; 

    void Start()
    {
        GlobalVariables.Instance.SetVariable("Player", playerTransform);
        GlobalVariables.Instance.SetVariable("Campervan", CampervanTransform);
    }
}
