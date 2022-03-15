using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDestroyed(Enemy enemy);
    public event EnemyDestroyed OnEnemyDestroyed;

    public int pointValue = 50;
    
    private int enemyHealth = 20;
    private Rigidbody2D enemy;

    private ScoreManager sm;

    public AudioSource audioSrc;
    public AudioClip audioOnDestroy;


    private bool destroy = false;
    
    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>(); 
        sm = GameObject.Find("Text (TMP)").GetComponent<ScoreManager>();
        audioSrc = GetComponent<AudioSource>();
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
                else if (enemy.gameObject.tag == "enemy4")
                {
                    sm.scoreIncEnemy4();
                }

                sm.setScore();
                StartCoroutine(DelayForAnimation());
                
                
            }

            
            Debug.Log("Ouch!");
        }
    }
    
    IEnumerator DelayForAnimation()
    {
        enemy.GetComponent<Animator>().SetTrigger("Destroy");
        audioSrc.clip = audioOnDestroy;
        audioSrc.Play();
        yield return new WaitForSeconds(2);
        Destroy(enemy.gameObject);
    }
}
