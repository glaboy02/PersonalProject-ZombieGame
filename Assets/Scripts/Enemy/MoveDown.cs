
using UnityEngine;
using System;

public class MoveDown : MonoBehaviour
{
    private float speed = 1f;
    private GameObject enemyGoal;
    private SpriteRenderer enemySprite;
    [NonSerialized] public bool isDead = false;

    void Start()
    {
        enemyGoal = GameObject.Find("Girl");
        enemySprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoveEnemyDown();
    }
    
    public void MoveEnemyDown()
    {
        if (enemyGoal == null) return;
        
        if (isDead) return;

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
