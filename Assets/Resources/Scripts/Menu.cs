using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Menu : MonoBehaviour
{
    public GameObject menu;

    public GameObject buttonsMenu;

    public GameObject authorsPanel;

    public GameObject settingsPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeInHierarchy)
            {
                Time.timeScale = 1;
                menu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                menu.SetActive(true);
                BackToMenu();
            }
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Debug.Log("NewGame");
    }

    public void LoadGame()
    {
        SaveLoad.Load();
    }

    public void SaveGame()
    {
        SaveLoad.Save();
    }

    public void Settings()
    {
        buttonsMenu.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Authors()
    {
        buttonsMenu.SetActive(false);
        authorsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        settingsPanel.SetActive(false);
        authorsPanel.SetActive(false);
        buttonsMenu.SetActive(true);       
    }

    public void ExitGame()
    {
        SaveLoad.SaveIni();
        Application.Quit();
    }
}

