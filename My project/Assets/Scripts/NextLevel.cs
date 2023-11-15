using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private collectPoint cp;
    private int points;
    private int time;

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Flagpole")) {
            cp = GetComponent<collectPoint>();
            points = cp.GetPoint();
            time = Timer.singleton.GetTime();
            GameManager.singleton.UpdateTotalShards(points);
            GameManager.singleton.UpdateTotalTime(time);
            if(GameManager.singleton == null) {
                Debug.Log("It null");
            }

            string currentLevelName = SceneManager.GetActiveScene().name;
            if (currentLevelName == "Level1")
            {
                SceneManager.LoadScene("Level2");
            } else if (currentLevelName == "Level2") {
                SceneManager.LoadScene("Level3");
            } else {
                SceneManager.LoadScene("GameComplete");
            }


        }
    }
}
