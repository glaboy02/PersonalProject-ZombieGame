

using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject abilityUI;
    private float enemyCount = 0;
    private int waveNumber = 1;
    private bool hasSpawnedCards = false;
    private int increaseDifficulty = 1;
    private int removeEnemy = 0;

    public static EnemySpawner Instance;

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

    public void SpawnEnemy(int enemyIndex, int removeCount)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 9, 0);

        int startIndex = removeCount;
        int endIndex = enemyIndex;

        // Make sure we have valid indices
        startIndex = Mathf.Clamp(startIndex, 0, enemyPrefabs.Length - 1);
        endIndex = Mathf.Clamp(endIndex, startIndex + 1, enemyPrefabs.Length);

        // Get available enemies from the range
        int count = endIndex - startIndex;
        GameObject[] availableEnemies = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            availableEnemies[i] = enemyPrefabs[startIndex + i];
        }

        // Pick a random enemy from available pool
        int randomEnemyIndex = Random.Range(0, availableEnemies.Length);
        Instantiate(availableEnemies[randomEnemyIndex], spawnPosition, transform.rotation);

    }

    public void SpawnEnemyWaves()
    {
        if (waveNumber % 5 == 0 && increaseDifficulty < enemyPrefabs.Length)
        {
            increaseDifficulty++;
        }

        if (waveNumber >= (enemyPrefabs.Length * 5))
        {
            int maxRemovals = enemyPrefabs.Length - 1;
            int roundsSinceRound25 = waveNumber - (enemyPrefabs.Length * 5);
            int removalsToApply = (roundsSinceRound25 / 5) + 1;
            removeEnemy = Mathf.Min(removalsToApply, maxRemovals);
        }
        else
        {
            removeEnemy = 0;
        }

        for (int i = 0; i < waveNumber; i++)
        {
            GameManager.Instance.RoundCounter(waveNumber);
            SpawnEnemy(increaseDifficulty, removeEnemy);
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

    public void ResetSpawner()
    {
        waveNumber = 1;
        increaseDifficulty = 1;
        removeEnemy = 0;
        hasSpawnedCards = false;
        enemyCount = 0;
    }
}

