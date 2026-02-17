using UnityEngine;
using System.Collections;


public class EnemyController : MonoBehaviour
{
    public int enemyHealth = 100;
    public int enemyDamage = 20;
    private bool isDead = false;
    private float lowerBound = -8f;
    private GameObject player;
    private Animator animator;
    public AudioClip hitSound;
    public AudioClip deathSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
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
        animator.SetTrigger("Hit");
        AudioSource.PlayClipAtPoint(hitSound, transform.position, 1f);


        if (enemyHealth <= 0)
        {
            EnemyDead();
        }
    }

    public void EnemyDead()
    {
        isDead = true;
        animator.SetTrigger("Dead");
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        gameObject.GetComponent<MoveDown>().isDead = true;
        AudioSource.PlayClipAtPoint(deathSound, transform.position, 1f);
        StartCoroutine(DestroyAfterDelay(1f));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("EnemyHealth detected trigger with " + other.gameObject.name);
        if (other.gameObject.CompareTag("Bullet"))
        {
            int playerDamage = player.GetComponent<PlayerController>().playerDamage;
            BulletDamage bulletDamage = other.gameObject.GetComponent<BulletDamage>();

            int totalDamage = bulletDamage.damageAmount + playerDamage;
            TakeDamage(totalDamage);
            Destroy(other.gameObject);
        }
    }

}

