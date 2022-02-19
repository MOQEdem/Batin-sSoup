using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameMenu : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
