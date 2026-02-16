using UnityEngine;
using UnityEngine.SceneManagement;
# if UNITY_EDITOR
using UnityEditor;
# endif

public class MenuUIHandler : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        SaveManager.Instance.SaveLongestRun();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else

        Application.Quit();
# endif
    }

    public void BackToMenu()
    {
        if (SaveManager.Instance.currentRun > SaveManager.Instance.longestRun)
        {
            SaveManager.Instance.longestRun = SaveManager.Instance.currentRun;
        }
        // SaveManager.Instance.longestRun = SaveManager.Instance.currentRun;
        SaveManager.Instance.SaveLongestRun();
        SceneManager.LoadScene(0);
    }

    public void ResetLongestRun()
    {
        SaveManager.Instance.longestRun = 0;
        SaveManager.Instance.SaveLongestRun();
    }

}
