using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    float elapsedTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTimerDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameplayPaused)
        {
            return;
        }

        elapsedTime += Time.deltaTime;
        UpdateTimerDisplay();
    }
    public static bool GameplayPaused { get; private set; }

    public static void SetGameplayPaused(bool paused)
    {
        GameplayPaused = paused;
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
