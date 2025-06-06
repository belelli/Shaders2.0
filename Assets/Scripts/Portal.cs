using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    
    public Transform target;
    



    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = target.position;
        var player = other.GetComponent<PlayerMovement>();
        if (player)
        {
            Debug.Log("coillider");
            player.controller.enabled = false;
            other.transform.position = target.position;
            other.transform.rotation = target.rotation;
            player.controller.enabled = true;

        }
        
    }
}
