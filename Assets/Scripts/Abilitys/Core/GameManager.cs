using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static bool GameplayPaused { get; private set; }

    public static void SetGameplayPaused(bool paused)
    {
        GameplayPaused = paused;
    }
}
