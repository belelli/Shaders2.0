using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMonitorManager : MonoBehaviour
{
[Header("Cameras")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera[] monitorCameras;

    [Header("Player")]
    [SerializeField] private MonoBehaviour playerMovement;
    [SerializeField] private MonoBehaviour mouseLook;
    
    [SerializeField] private GameObject monitorCanvas;

    private bool monitorMode = false;
    private int currentCamera = 0;

    private void Start()
    {
        mainCamera.enabled = true;

        foreach (Camera cam in monitorCameras)
            cam.enabled = false;
    }

    private void Update()
    {
        if (!monitorMode)
            return;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            NextCamera();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            PreviousCamera();

        if (Input.GetKeyDown(KeyCode.Escape))
            ExitMonitorMode();
    }

    public void EnterMonitorMode()
    {
        if (monitorMode)
            return;

        monitorMode = true;
        currentCamera = 0;

        mainCamera.enabled = false;

        if (playerMovement != null)
            playerMovement.enabled = false;

        if (mouseLook != null)
            mouseLook.enabled = false;

        ActivateCamera(currentCamera);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        monitorCanvas.SetActive(true);
    }

    public void ExitMonitorMode()
    {
        monitorMode = false;

        foreach (Camera cam in monitorCameras)
            cam.enabled = false;

        mainCamera.enabled = true;

        if (playerMovement != null)
            playerMovement.enabled = true;

        if (mouseLook != null)
            mouseLook.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        monitorCanvas.SetActive(false);
    }

    private void NextCamera()
    {
        currentCamera++;

        if (currentCamera >= monitorCameras.Length)
            currentCamera = 0;

        ActivateCamera(currentCamera);
    }

    private void PreviousCamera()
    {
        currentCamera--;

        if (currentCamera < 0)
            currentCamera = monitorCameras.Length - 1;

        ActivateCamera(currentCamera);
    }

    private void ActivateCamera(int index)
    {
        for (int i = 0; i < monitorCameras.Length; i++)
            monitorCameras[i].enabled = (i == index);
    }
}
