using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
    public GameObject ui;
    public SceneFader fader;
    public string mainMenuName = "MainMenu";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void Retry()
    {
        Pause();
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Continue()
    {
        Pause();
    }

    public void GoToMainMenu()
    {
        Pause();
        fader.FadeTo(mainMenuName);
    }
}
