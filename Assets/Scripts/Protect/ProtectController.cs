using UnityEngine;

public class ProtectController : MonoBehaviour
{
    private int protectHealth = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void TakeDamage(GameObject gameObject, int damage)
    {
        protectHealth -= damage;
        if (protectHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // int damage = other.
            //             gameObject.
            //             GetComponent<EnemyController>().
            //             enemyDamage;
            
            // TakeDamage(gameObject, damage);

        }
    }
}
