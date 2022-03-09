using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Bunker : MonoBehaviour
{
    private int bunkerHealth = 80;
    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
        bunkerHealth = bunkerHealth - 10;
        Debug.Log(bunkerHealth);

        Debug.Log("HIT");
        if (bunkerHealth <= 10)
        {
            Destroy(body.gameObject);
        }
    }
}