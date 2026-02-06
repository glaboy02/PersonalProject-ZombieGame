

using UnityEngine;

namespace RPG.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public GameObject[] enemyPrefabs;

        private float spawnDelay = 2.0f;
        private float spawnInterval = 1.0f;
        private float lowerBound = -8f;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y < lowerBound)
            {
                Destroy(gameObject);
            }
        }

        public void SpawnEnemy()
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 8, 0);
            int randomEnmyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomEnmyIndex], spawnPosition, transform.rotation);
        }
        // private void OnCollisionEnter(Collision other)
        // {
        //     Debug.Log("Collision detected with " + other.gameObject.name);
        //     if (other.gameObject.CompareTag("Bullet"))
        //     {
        //         Debug.Log("Enemy hit by bullet");
        //         TakeDamage(enemyHealth.damageAmount);
        //         Destroy(other.gameObject);
        //     }
        // }
    }
}
