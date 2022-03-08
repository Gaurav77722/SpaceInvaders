using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDestroyed(Enemy enemy);
    public event EnemyDestroyed OnEnemyDestroyed;

    public int pointValue = 50;
    
    private int enemyHealth = 80;
    private Rigidbody2D enemy;

    private ScoreManager sm;

    private Animator enemyAnimator;

    private bool destroy = false;
    
    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemy = GetComponent<Rigidbody2D>(); 
        sm = GameObject.Find("Text (TMP)").GetComponent<ScoreManager>();
    }

    //-----------------------------------------------------------------------------
    void OnCollisionEnter2D(Collision2D collision)
    {
        // todo - trigger death animation
        if (collision.gameObject.tag == "byPlayer")
        {
            Destroy(collision.gameObject); // destroy bullet


            if (enemyHealth > 20)
            {
                enemyHealth = enemyHealth - 20;
            }
            else if (enemyHealth <= 20)
            {
                if (enemy.gameObject.tag == "enemy1")
                {
                    sm.scoreIncEnemy1();
                }
                else if (enemy.gameObject.tag == "enemy2")
                {
                    sm.scoreIncEnemy2();
                }
                else if (enemy.gameObject.tag == "enemy3")
                {
                    sm.scoreIncEnemy3();
                }

                sm.setScore();
                Destroy(enemy.gameObject);
                destroy = true;
            }


            enemyAnimator.SetBool("onDestroy", destroy);

            Debug.Log("Ouch!");
        }
    }
}
