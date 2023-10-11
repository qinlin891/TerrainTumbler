using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] Image[] hearts;    
    // private int health = 3;
    [SerializeField] int health = 3;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;
    [SerializeField] GameObject gameover;
    [SerializeField] GameObject musicPlayer;
    AudioSource audio;

    void Awake() {
        audio = musicPlayer.GetComponent<AudioSource>();
    }


    public void hit() {
        health--;
        if(health == 0) {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameover.SetActive(true);
            audio.Stop();
            health = 3;
        }
        displayHearts();

    }

    void displayHearts() {
        for(int i = 0; i < hearts.Length; i++) {
            if(i < health) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }
        }
    }




}
