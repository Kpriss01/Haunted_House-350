using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public float volume;
    public AudioMixer audioMixer;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("MainVolume", volume);

    }

    public void SettingsExitButton()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
