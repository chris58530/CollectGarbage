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
    List<GameObject> customers = new List<GameObject>();

    private bool isTriggerCustomer;

    public void InitSystem()
    {
        isTriggerCustomer = false;
        alienCar.Show();
    }

    public void OpenResteruant()
    {
        if (!isTriggerCustomer)
        {
            StartCoroutine(GenerateCustomers());
            isTriggerCustomer = true;
        }
    }

    private IEnumerator GenerateCustomers()
    {

        Vector3 spawnPos = alienCar.transform.position;
        Vector3 endPos = playersCar.position;


        for (int i = 0; i < 5; i++)
        {
            GameObject newCustomer = Instantiate(customer, spawnPos,
            Quaternion.identity);
            newCustomer.transform.DOMove(endPos, 5.0f);
            customers.Add(newCustomer);
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void CloseResteraunt()
    {
        Vector3 endPos = playersCar.position;

        foreach (var costomer in customers)
        {
            costomer.transform.DOMove(endPos, 2.0f);

        }
        customers.Clear();
        
    }



    public void ShutDownSystem()
    {
        alienCar.Hide();

    }
}
