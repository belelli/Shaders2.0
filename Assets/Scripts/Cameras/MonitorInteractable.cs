using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorInteractable : MonoBehaviour
{
    [SerializeField] private CameraMonitorManager cameraManager;
    [SerializeField] private GameObject InteractCanvas;
    

    private bool playerInside;


    private void Start()
    {
        InteractCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            InteractCanvas.SetActive(true);
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            InteractCanvas.SetActive(false);
        }
            
    }

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            cameraManager.EnterMonitorMode();
            InteractCanvas.SetActive(false);
        }
    }
}
