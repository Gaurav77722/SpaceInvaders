using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Bunker : MonoBehaviour
{
    private int bunkerHealth = 80;

    void OnCollisionEnter()
    {
        bunkerHealth = bunkerHealth - 10;

        Debug.Log("HIT");
        if (bunkerHealth <= 10)
        {
            Destroy(GetComponent<GameObject>());
        }
    }
}