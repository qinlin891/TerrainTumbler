using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timerText;
    int seconds = 0;
    bool isPaused = false;
    Coroutine timerCoroutine;

    public static Timer singleton;

    void Awake() {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start(){
        timerText = GetComponent<Text>();
        timerCoroutine = StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine() {
        while(true) {
            yield return new WaitForSeconds(1);
            seconds += 1;
            timerText.text = seconds.ToString();
        }
        yield return null;
    }

    public int GetTime() {
        return seconds;
    }

    public void PauseTimer() {
        isPaused = true;
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine); // Stop the coroutine immediately
        }
    }

    public void ResumeTimer() {
        isPaused = false;
        timerCoroutine = StartCoroutine(TimerRoutine());
    }

    public bool IsPaused() {
        return isPaused;
    }
}
