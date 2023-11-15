using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuHandler : MonoBehaviour
{
    public void RestartGame() {
        string currentLevelName = SceneManager.GetActiveScene().name;
        if (currentLevelName == "Level1")
        {
            SceneManager.LoadScene("Level1");
        } else if (currentLevelName == "Level2") {
            SceneManager.LoadScene("Level2");
        } else {
            SnowmanController.ClearSnowballPool();
            SceneManager.LoadScene("Level3");
        }
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
