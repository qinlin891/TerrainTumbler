using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuHandler : MonoBehaviour
{
    public void RestartGame() {
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
