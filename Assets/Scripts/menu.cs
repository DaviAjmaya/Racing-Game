using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // <<<<<< ADD THIS.

public class menu : MonoBehaviour
{
    public void Start()
    {
    }
    public void newGame()
    {
        StartGame.start = false;
        StartGame.end = false;
        SceneManager.LoadScene("randomtrack");

    }
    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}