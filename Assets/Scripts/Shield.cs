using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int life = 3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("normalBullet"))
        {
            Damage();
        }
        
    }

    private void Damage()
    {
        life--;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
