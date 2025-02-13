using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using DG.Tweening;
using UnityEngine;

public class ResteruantSystem : MonoBehaviour, ISystem
{

    [SerializeField] private AlienCar alienCar;
    [SerializeField] private Transform playersCar;
    [SerializeField] private GameObject customer;
   

    public void InitSystem()
    {
        alienCar.Show();
    }

    public void OpenResteruant()
    {
        alienCar.OpenResteruant();
    }


    public void CloseResteraunt()
    {
        alienCar.CloseResteraunt();
        
    }



    public void ShutDownSystem()
    {
        alienCar.Hide();

    }
}
