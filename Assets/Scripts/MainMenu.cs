using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        //Character select here later
        SceneManager.LoadSceneAsync("Stage-1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadSceneAsync("SettingsMenu");
    }
}
