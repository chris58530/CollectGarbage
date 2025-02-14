using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;

public class AlienCar : MonoBehaviour, IObject
{
    [SerializeField] private GameObject customer;
    List<GameObject> customers = new List<GameObject>();

    private bool isTriggerCustomer;
    bool isOpenResteraunt;
    public void OpenResteruant()
    {
        if (!isTriggerCustomer)
        {
            isTriggerCustomer = true;
            isOpenResteraunt = true;
            StartCoroutine(GenerateCustomers());

        }

    }

    public void CloseResteraunt()
    {
        foreach (var customer in customers)
        {
            customer.transform.DOMove(transform.position, 2.0f);
        }
        Observable.Timer(TimeSpan.FromSeconds(3)).Subscribe(_ =>
        {
            foreach (var customer in customers)
            {
                Destroy(customer);
                customers.Remove(customer);
            }
            Hide();
        }).AddTo(this);
    }
    IEnumerator GenerateCustomers()
    {
        var endPos = CarSystem.Instance.customersBuyingPoint;
        while (isOpenResteraunt)
        {

            for (int i = 0; i < 3; i++)
            {


                GameObject newCustomer = Instantiate(customer, transform.position, Quaternion.identity);
                Sequence sequence = DOTween.Sequence();
                sequence.Append(newCustomer.transform.DOMove(endPos.position, 5.0f))
                        .AppendInterval(1.0f)
                        .Append(newCustomer.transform.DOMove(transform.position, 5.0f));
                customers.Add(newCustomer);
                yield return sequence.WaitForCompletion();
                customers.Add(newCustomer);


            }

            yield return new WaitForSeconds(2);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        customers.Clear();

        gameObject.SetActive(false);

    }
}
