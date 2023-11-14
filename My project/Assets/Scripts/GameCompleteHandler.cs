using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompleteHandler : MonoBehaviour
{
    public void PlayAgain() {
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}