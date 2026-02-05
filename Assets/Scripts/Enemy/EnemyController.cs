
using UnityEngine;

namespace RPG.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private bool isDead = false;
        private EnemyHealth enemyHealth;
        public GameObject[] enemyPrefabs;

        private float spawnDelay = 2.0f;
        private float spawnInterval = 1.0f;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            enemyHealth = GetComponent<EnemyHealth>();
            InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TakeDamage(int damage)
        {
            if (isDead) return;

            // Reduce health by damage amount
            // If health <= 0, call EnemyDead()
            if (enemyHealth.health <= 0)
            {
                EnemyDead();
            }

            enemyHealth.health -= damage;
        }

        public void EnemyDead()
        {
            isDead = true;
        }

        public void SpawnEnemy()
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 8, 0);
            int randomEnmyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomEnmyIndex], spawnPosition, transform.rotation);
        }
        private void OnCollisionEnter(Collision other) 
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                TakeDamage(enemyHealth.damageAmount);
            }
        }
    }
}
