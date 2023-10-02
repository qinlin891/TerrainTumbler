using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuHandler : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("Playground");
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
