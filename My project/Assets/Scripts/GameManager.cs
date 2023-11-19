using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int totalTime = 0;
    private int totalShards = 0;

    public static GameManager singleton;

    void Awake(){
        if (singleton == null){
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public void UpdateTotalShards(int shardsCollected){
        totalShards += shardsCollected;
    }

    public void UpdateTotalTime(int levelTime){
        totalTime += levelTime;
    }

    public string GetTotalShards() {
        return totalShards.ToString();
    }

    public int GetTimeInSec() {
        return totalTime;
    }

    public string GetFormatTime()
    {
        int minutes = totalTime / 60;
        int seconds = totalTime % 60;

        if (minutes == 0){
            return seconds + " seconds";
        } else if (seconds == 0){
            return minutes + " minutes";
        } else {
            return minutes + " minute" + (minutes > 1 ? "s" : "") + " and " + seconds + " seconds";
        }
    }

    public void ResetGame()
    {
        totalTime = 0;
        totalShards = 0;
    }
}
