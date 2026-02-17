

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject abilityUI;
    private float enemyCount = 0;
    private int waveNumber = 1;
    private bool hasSpawnedCards = false;
    private int increaseDifficulty = 1;

    void Start()
    {
        SpawnEnemyWaves();
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0 && !hasSpawnedCards)
        {

            abilityUI.SetActive(true);
            GameManager.SetGameplayPaused(true);
            AbilityController.Instance.SpawnAbilityCards();
            hasSpawnedCards = true;
        }
    }

    public void SpawnEnemy(int enemyIndex)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 8, 0);
        int randomEnemyIndex = Random.Range(0, enemyIndex);
        Instantiate(enemyPrefabs[randomEnemyIndex], spawnPosition, transform.rotation);
    }

    public void SpawnEnemyWaves()
    {
        if (waveNumber % 5 == 0)
        {
            increaseDifficulty++;
            Debug.Log("Difficulty Increased! Enemy Index: " + increaseDifficulty);
        }

        for (int i = 0; i < waveNumber; i++)
        {
            GameManager.Instance.RoundCounter(waveNumber);
            SpawnEnemy(increaseDifficulty);
        }
        waveNumber++;
        hasSpawnedCards = false;
    }

    public void OnWaveEnded()
    {
        abilityUI.SetActive(true);
    }

    public void StartNextWave()
    {
        GameManager.SetGameplayPaused(false);
        SpawnEnemyWaves();
    }

    // public void SpawnEliteEnemy()
    // {
    //     Vector3 spawnPosition = new Vector3(0, 8, 0);
    //     int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
    //     Instantiate(enemyPrefabs[enemyPrefabs.Length - 1], spawnPosition, transform.rotation);
    // }
}

