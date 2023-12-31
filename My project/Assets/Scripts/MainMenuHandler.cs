using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuHandler : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("Level1");
        GameManager.singleton.ResetGame();
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
