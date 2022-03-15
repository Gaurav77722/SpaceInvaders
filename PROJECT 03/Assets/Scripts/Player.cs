using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;
    [FormerlySerializedAs("shottingOffset")] public Transform shootOffsetTransform;

    private Animator playerAnimator;
    private static readonly int IsShootT = Animator.StringToHash("isShootT");
    private Rigidbody2D body;
    private int playerHealth = 10;
    private static readonly int Destroy1 = Animator.StringToHash("Destroy");
    
    public AudioSource audioSrc;
    public AudioClip audioOnDestroy;
    public AudioClip audioOnShoot;

    //-----------------------------------------------------------------------------
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        float horizontalExtent = Camera.main.orthographicSize * Camera.main.aspect;
        float axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector2.right * axis, ForceMode2D.Force);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // todo - trigger a "shoot" on the animator
            playerAnimator.SetTrigger(IsShootT);
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            audioSrc.clip = audioOnShoot;
            audioSrc.Play();
            shot.tag = "byPlayer";
            Debug.Log("Bang!");

            
            Destroy(shot, 8f);
        }
        
        if (Mathf.Abs(body.position.x) > horizontalExtent)
        {
            body.velocity = new Vector2(-body.velocity.x, body.velocity.y);
        }
    }
    
    IEnumerator DelayForAnimation()
    {
        playerAnimator.SetTrigger(Destroy1);
        yield return new WaitForSeconds(5);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject); // destroy bullet
        if (collision.gameObject.tag == "byEnemy")
        {
            playerHealth = playerHealth - 10;
            if (playerHealth <= 10)
            {
                audioSrc.clip = audioOnDestroy;
                audioSrc.Play();
                StartCoroutine(DelayForAnimation());
                Destroy(body.gameObject);
                SceneManager.LoadScene("Credits");
            }
        }
    }
    
    
}
