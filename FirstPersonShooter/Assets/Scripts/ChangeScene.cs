using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public PlayerHealth playerHealth;
    //Load first Scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Quits the game
    public void ExitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    //Used to change scene to load Main Menu
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

}
