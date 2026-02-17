using UnityEngine;
using System.IO;
using System;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }
    public int longestRun;
    public int currentRun;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadLongestRun();
    }

    [Serializable]
    class SaveData
    {
        public int longestRun;
        public int currentRun;
    }

    public void SaveLongestRun()
    {
        SaveData data = new SaveData();
        data.longestRun = longestRun;
        data.currentRun = currentRun;
        if (currentRun > longestRun)
        {
            data.longestRun = currentRun;
        }

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadLongestRun()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            longestRun = data.longestRun;
        }
    }
    

}
