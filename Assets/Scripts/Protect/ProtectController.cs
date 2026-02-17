using UnityEngine;


public class ProtectController : MonoBehaviour
{
    private int protectHealth = 1;
    public AudioClip hitSound;

    private void TakeDamage(GameObject gameObject, int damage)
    {
        protectHealth -= damage;
        if (protectHealth <= 0)
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            GameManager.Instance.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            int damage = other.
                        gameObject.
                        GetComponent<EnemyController>().
                        enemyDamage;

            TakeDamage(gameObject, damage);
        }
    }

}



