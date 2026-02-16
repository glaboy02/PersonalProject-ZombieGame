using UnityEngine;
using TMPro;
using System.Collections;
using System.Xml.Linq;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI longestRunText;
    public TextMeshProUGUI timerText;
    float elapsedTime = 0f;
    float longestRunTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTimerDisplay();
        UpdateLongestRunDisplay();
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

        SaveManager.Instance.currentRun = Mathf.FloorToInt(elapsedTime);

    }

    public void UpdateLongestRunDisplay()
    {

        longestRunTime = SaveManager.Instance.longestRun;
        int minutes = Mathf.FloorToInt(longestRunTime / 60f);
        int seconds = Mathf.FloorToInt(longestRunTime % 60f);
        longestRunText.text = string.Format("Longest Run: {0:00}:{1:00}", minutes, seconds);
    }

    // public void CheckForLongestRun()
    // {
    //     if (elapsedTime > longestRunTime)
    //     {
    //         SaveManager.Instance.longestRun = SaveManager.Instance.currentRun;
    //         UpdateLongestRunDisplay();
    //     }
    // }

}
