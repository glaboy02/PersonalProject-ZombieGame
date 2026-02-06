using UnityEngine;

namespace RPG.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public int health = 100;
        public int damageAmount = 20;
        private bool isDead = false;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }

        }

        public void TakeDamage(int damage)
        {
            if (isDead) return;

            // Reduce health by damage amount
            // If health <= 0, call EnemyDead()
            if (health <= 0)
            {
                EnemyDead();
            }

            health -= damage;
        }

        public void EnemyDead()
        {
            isDead = true;
            Debug.Log("Enemy is dead");
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("EnemyHealth detected collision with " + other.gameObject.name);
            if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Enemy"))
            {
                health -= damageAmount;
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("EnemyHealth detected trigger with " + other.gameObject.name);
            if (other.gameObject.CompareTag("Bullet"))
            {
                health -= damageAmount;
            }
        }

    }

}