
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed = 1f;

    private GameObject enemyGoal;
    private SpriteRenderer enemySprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyGoal = GameObject.Find("Girl");
        enemySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemyDown();
    }
    
    public void MoveEnemyDown()
    {
        if (enemyGoal == null)
            return;

        Vector3 direction = (enemyGoal.transform.position - transform.position).normalized;

        if (direction.x < 0)
        {
            enemySprite.flipX = true;
        }
        else if (direction.x > 0)
        {
            enemySprite.flipX = false;
        }
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
