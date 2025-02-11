using _.Scripts.Tools;
using UnityEngine;
using UnityEngine.UI;

public class CarSystem : Singleton<CarSystem>, ISystem
{
    public GameObject carUI; // UI 元素
    public bool isInCar;

    [SerializeField] private GameObject playerInCar;

    public void InitSystem()
    {
    }

    public void RequestChangePlayControl()
    {
        switch (GameManager.Instance.playControlState)
        {

            case PlayControlState.OutCar:
                playerInCar.SetActive(false);
                GameManager.Instance.ChangePlayControlState(PlayControlState.InCar);

                break;
            case PlayControlState.InCar:
                playerInCar.SetActive(true);
                GameManager.Instance.ChangePlayControlState(PlayControlState.OutCar);

                break;

        }
    }

    public void ShutDownSystem()
    {
    }
}