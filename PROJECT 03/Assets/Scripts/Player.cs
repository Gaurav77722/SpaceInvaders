using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;
    [FormerlySerializedAs("shottingOffset")] public Transform shootOffsetTransform;

    private Animator playerAnimator;
    private static readonly int IsShootT = Animator.StringToHash("isShootT");
    private Rigidbody2D body;

    //-----------------------------------------------------------------------------
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
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
            shot.tag = "byPlayer";
            Debug.Log("Bang!");

            
            Destroy(shot, 8f);
        }
        
        if (Mathf.Abs(body.position.x) > horizontalExtent)
        {
            body.velocity = new Vector2(-body.velocity.x, body.velocity.y);
        }
    }
}
