using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorInteractable : MonoBehaviour
{
    [SerializeField] private CameraMonitorManager cameraManager;
    

    private bool playerInside;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            cameraManager.EnterMonitorMode();
        }
    }
}
