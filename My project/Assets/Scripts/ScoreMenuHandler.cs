using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenuHandler : MonoBehaviour
{
    [SerializeField] Text score1;
    [SerializeField] Text score2;
    [SerializeField] Text score3;

    public void Show() {
        GetComponent<Canvas>().enabled = true;
        DisplayTopScores();
    }

    public void Hide() {
        GetComponent<Canvas>().enabled = false;
    }

    private void DisplayTopScores() {
        List<int> topScores = new List<int>();
        string topScoresString = PlayerPrefs.GetString("TopScores", "");

        if (!string.IsNullOrEmpty(topScoresString)) {
            string[] scoresArray = topScoresString.Split(',');

            foreach (string score in scoresArray) {
                if (int.TryParse(score, out int parsedScore)) {
                    topScores.Add(parsedScore);
                }
            }
        }

        while (topScores.Count < 3) {
            topScores.Add(0);
        }

        score1.text = "#1: " + GetFormatTime(topScores[0]);
        score2.text = "#2: " + GetFormatTime(topScores[1]);
        score3.text = "#3: " + GetFormatTime(topScores[2]);
    }

    private string GetFormatTime(int totalTime)
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
}
