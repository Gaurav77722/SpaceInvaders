using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy : MonoBehaviour
{
    
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(Vector2.left * 30f, ForceMode2D.Impulse);
        body.gameObject.tag = "enemy4";
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalExtent = Camera.main.orthographicSize * Camera.main.aspect;
        
        
        
        if (body.position.x > 20)
        {
            body.AddForce(Vector2.left * 10f, ForceMode2D.Impulse);
        }
        else if (body.position.x < -20)
        {
            body.AddForce(Vector2.right * 10f, ForceMode2D.Impulse);
        }
    }
    
}
