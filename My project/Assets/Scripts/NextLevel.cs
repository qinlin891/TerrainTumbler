using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Flagpole")) {
            SceneManager.LoadScene("Level2");
        }
    }
}
