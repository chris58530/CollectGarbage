using System;
using UnityEngine;
using TMPro;
public enum TimeOfDay
{
    Morning,
    Afternoon,
    Evening,
    Night
}
public class TimeSystem : MonoBehaviour, ISystem
{
    [Header("Time Settings")]
    public float dayLengthInSeconds = 60f; // 一天的長度（秒）
    public int dayStartHour = 6; // 白天開始時間
    public int nightStartHour = 18; // 夜晚開始時間

    [Header("Lighting Settings")]
    public Light directionalLight; // 主燈光
    public Color dayColor = Color.white; // 白天光線顏色
    public Color nightColor = Color.blue; // 夜晚光線顏色
    public float maxLightIntensity = 1f; // 白天燈光強度
    public float minLightIntensity = 0.1f; // 夜晚燈光強度

    [Header("Debug Info")]
    public bool isDaytime; // 當前是否為白天
    public float currentTime; // 當前時間（範圍：0 ~ 1）
    public int currentHour; // 當前小時（0-24 小時制）



    TimeSystemView view;

    public bool inGame;

    public void InitSystem()
    {
        view = GameObject.FindObjectOfType<TimeSystemView>();
        view.InitView(this);

    }
    public void ShutDownSystem() { }

    public void StartSystem()
    {
        inGame = true;
        // 初始化
        currentHour = 5;
        currentTime = currentHour / 24f; // 設定遊戲開始時間為 5:00 AM
        isDaytime = currentHour >= dayStartHour && currentHour < nightStartHour;

        // 觸發 5:00 AM 事件
        Debug.Log("Game starts at 5:00 AM. Morning event triggered.");
    }
    public void CloseSystem()
    {
        inGame = false;
    }

    private void Update()
    {
        if (!inGame) return;
        // 時間更新
        UpdateTime();

        // 光線更新
        UpdateLighting();

        // UI 顯示更新
        UpdateTimeView();
    }

    private void UpdateTime()
    {
        // 計算一天的進度（0 ~ 1 循環）
        currentTime += Time.deltaTime / dayLengthInSeconds;
        if (currentTime > 1f)
        {
            currentTime -= 1f;
        }
        // 計算當前小時（0-24 小時制）
        currentHour = Mathf.FloorToInt(currentTime * 24);

        // 判斷白天與夜晚
        bool wasDaytime = isDaytime;
        isDaytime = currentHour >= dayStartHour && currentHour < nightStartHour;

        if (isDaytime != wasDaytime)
        {
            if (isDaytime)
            {
                Debug.Log("Daytime has started.");
                GameManager.Instance.ChangeGameState(GameState.SunRise);

            }
            else
            {
                GameManager.Instance.ChangeGameState(GameState.SunDown);

            }
        }

        if (currentHour == 5)
        {
            Debug.Log("It's 5:00 AM. Morning event triggered.");

        }
        else if (currentHour == 20)
        {
            GameManager.Instance.ChangeGameState(GameState.ResteruantOpen);

        }
        else if (currentHour == 24)
        {
            GameManager.Instance.ChangeGameState(GameState.ResteruantClose);
        }
    }

    private void UpdateLighting()
    {
        if (directionalLight == null) return;

        Color targetColor = isDaytime ? dayColor : nightColor;
        float targetIntensity = isDaytime ? maxLightIntensity : minLightIntensity;

        // 動態調整光線顏色與強度
        directionalLight.color = Color.Lerp(directionalLight.color, targetColor, Time.deltaTime);
        directionalLight.intensity = Mathf.Lerp(directionalLight.intensity, targetIntensity, Time.deltaTime);
    }

    private void UpdateTimeView()
    {
        view.UpdateTime(currentHour);
        view.UpdateDay(isDaytime);
    }
}
