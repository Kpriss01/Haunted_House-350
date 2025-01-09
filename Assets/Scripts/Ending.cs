using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject FadeLost;
    [SerializeField] GameObject FadeWin;
    [SerializeField] GameObject reminder;

    private bool failing = false;
    private bool winning = false;
    void Start()
    {
        FadeLost.gameObject.SetActive(false);
        FadeWin.gameObject.SetActive(false);
        reminder.gameObject.SetActive(true);

    }
    public void Update()
    {
        if (failing)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("monster");
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main Menu");
            }
        }
        else if (winning)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main Menu");
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            reminder.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    public void Fail()
    {
        FadeLost.gameObject.SetActive(true);
        failing = true;
    }
    public void Win()
    {
        FadeWin.gameObject.SetActive(true);
        winning = true;
    }
}
