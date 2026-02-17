using UnityEngine;
using UnityEngine.SceneManagement;
# if UNITY_EDITOR
using UnityEditor;
# endif

public class MenuUIHandler : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StartGame()
    {
        PlayClickSound();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        PlayClickSound();
        SaveManager.Instance.SaveLongestRun();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else

        Application.Quit();
# endif
    }

    public void BackToMenu()
    {
        PlayClickSound();
        if (SaveManager.Instance.currentRun > SaveManager.Instance.longestRun)
        {
            SaveManager.Instance.longestRun = SaveManager.Instance.currentRun;
        }
        SaveManager.Instance.SaveLongestRun();

        if (EnemySpawner.Instance != null)
        {
            Destroy(EnemySpawner.Instance.gameObject);
            EnemySpawner.Instance = null;
        }

        GameManager.SetGameplayPaused(false);
        GameManager.Instance.gameOver = false;
        GameManager.Instance.gameOverScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void ResetLongestRun()
    {
        PlayClickSound();
        SaveManager.Instance.longestRun = 0;
        SaveManager.Instance.SaveLongestRun();
    }

    private void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

}
