using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Flagpole")) {
            // SceneManager.LoadScene("Level2");
            string currentLevelName = SceneManager.GetActiveScene().name;
            if (currentLevelName == "Level1")
            {
                SceneManager.LoadScene("Level2");
            } else {
                SceneManager.LoadScene("Level3");
            }
        }
    }
}
