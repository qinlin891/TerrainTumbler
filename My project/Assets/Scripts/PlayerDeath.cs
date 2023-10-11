using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    Health health;

    void Awake() {
        health = GetComponent<Health>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Trap")) {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            health.hit();
        }
    }
}
