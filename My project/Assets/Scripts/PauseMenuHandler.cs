using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject pause;
    string currentLevelName;

    void Awake() {
        currentLevelName = SceneManager.GetActiveScene().name;
    }

    public void Resume() {
        Timer.singleton.ResumeTimer();
        pause.SetActive(false);
    }

    public void Restart() {
        if (currentLevelName == "Level1") {
            SceneManager.LoadScene("Level1");
        } else if (currentLevelName == "Level2") {
            SceneManager.LoadScene("Level2");
        } else {
             SceneManager.LoadScene("Level3");
        }
    }

    public void Quit() {
        GameManager.singleton.ResetGame();
        SceneManager.LoadScene("MainMenu");
    }
}
