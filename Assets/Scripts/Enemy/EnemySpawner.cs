

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject abilityUI;
    private float enemyCount = 0;
    private int waveNumber = 1;
    private bool hasSpawnedCards = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        SpawnEnemyWaves();
    }

    // Update is called once per frame
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

    public void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 8, 0);
        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randomEnemyIndex], spawnPosition, transform.rotation);
    }

    public void SpawnEnemyWaves()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
        }
        waveNumber++;
        hasSpawnedCards = false;
    }

    public void OnWaveEnded()
    {
        // Logic for when a wave ends
        Debug.Log("Wave Ended");
        abilityUI.SetActive(true);
    }

    public void StartNextWave()
    {
        // Logic for starting the next wave
        Debug.Log("Starting Next Wave");
        GameManager.SetGameplayPaused(false);
        SpawnEnemyWaves();
    }
}

