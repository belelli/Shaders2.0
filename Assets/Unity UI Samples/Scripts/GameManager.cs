using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Menu;
    public Gun gun;
    public static GameManager Instance { get; private set; }
    public int totalDrones;

    public int dronesDestroyed = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }
    
    
    private void Start()
    {
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;   
        gun.enabled = false;
    }
    
    public void DroneKilled()
    {
        dronesDestroyed++;
        if (dronesDestroyed >= totalDrones)
        {
            Debug.Log("All drones destroyed!");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;   

            SceneManager.LoadScene("WinScene");
        }
    }
}
