using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtonsController : MonoBehaviour
{
    public Gun gun;

    public GameObject instructionsPanel;

    public GameObject mainPanel;
    //public GameObject Menu;
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        gun.enabled = true;
    }

    public void Instructions()
    {
        mainPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }
    public void Back()
    {
        mainPanel.SetActive(true);
        instructionsPanel.SetActive(false);
    }
}
