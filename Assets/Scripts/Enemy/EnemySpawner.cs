

using UnityEngine;

namespace RPG.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject[] enemyPrefabs;

        private float spawnDelay = 2.0f;
        private float spawnInterval = 1.0f;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void SpawnEnemy()
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 8, 0);
            int randomEnmyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomEnmyIndex], spawnPosition, transform.rotation);
        }
    }
}
