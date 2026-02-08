using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public int enemyHealth = 100;
    public int enemyDamage = 20;
    private bool isDead = false;
    private float lowerBound = -8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }

    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            EnemyDead();
        }
    }

    public void EnemyDead()
    {
        isDead = true;
        // Debug.Log("Enemy is dead");
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("EnemyHealth detected trigger with " + other.gameObject.name);
        if (other.gameObject.CompareTag("Bullet"))
        {
            BulletDamage bulletDamage = other.gameObject.GetComponent<BulletDamage>();
            TakeDamage(bulletDamage.damageAmount);
        }
    }

}

