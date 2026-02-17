using UnityEngine;
using TMPro;
using System.Collections;
using System.Xml.Linq;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI longestRunText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI roundText;
    public GameObject gameOverScreen;
    float elapsedTime = 0f;
    float longestRunTime = 0f;
    public bool gameOver = false;
    public static GameManager Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateTimerDisplay();
        UpdateLongestRunDisplay();
    }

    void Update()
    {
        if (GameplayPaused)
        {
            return;
        }

        elapsedTime += Time.deltaTime;

        if (gameOver)
        {
            return;
        }
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

    public void GameOver()
    {
        gameOver = true;
        SetGameplayPaused(true);
        gameOverScreen.SetActive(true);
    }

    public void RoundCounter(int round)
    {
        roundText.text = "Round: " + round;
    }



}
