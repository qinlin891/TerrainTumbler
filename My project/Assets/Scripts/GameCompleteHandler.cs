using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompleteHandler : MonoBehaviour
{
    public void PlayAgain() {
        GameManager.singleton.ResetGame();
        SnowmanController.ClearSnowballPool();
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu() {
        GameManager.singleton.ResetGame();
        SnowmanController.ClearSnowballPool();
        SceneManager.LoadScene("MainMenu");
    }
}
