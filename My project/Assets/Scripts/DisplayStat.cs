using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStat : MonoBehaviour
{
      [SerializeField] Text Time;
      [SerializeField] Text Shards;

      private const string TOP_SCORES_KEY = "TopScores";
      private const int MAX_TOP_SCORES = 3;
      private List<int> topScores;

      void Awake() {
        LoadTopScores();
      }

      void Start() {
         Shards.text = "x " + GameManager.singleton.GetTotalShards();
         Time.text = "Time Used: " + GameManager.singleton.GetFormatTime();
         AddScore(GameManager.singleton.GetTimeInSec());
      }

      public void AddScore(int newScore) {
         topScores.Add(newScore);
         topScores.Sort((a, b) => b.CompareTo(a)); // Sort in descending order

         if (topScores.Count > MAX_TOP_SCORES)
         {
            topScores = topScores.GetRange(0, MAX_TOP_SCORES);
         }
         SaveTopScores();
      }

      private void LoadTopScores() {
         topScores = new List<int>();
         string topScoresString = PlayerPrefs.GetString(TOP_SCORES_KEY, "");

         if (!string.IsNullOrEmpty(topScoresString))
         {
            string[] scoresArray = topScoresString.Split(',');

            foreach (string score in scoresArray)
            {
                  if (int.TryParse(score, out int parsedScore))
                  {
                     topScores.Add(parsedScore);
                  }
            }
         }
      }

      private void SaveTopScores() {
         string scoresString = string.Join(",", topScores);
         PlayerPrefs.SetString(TOP_SCORES_KEY, scoresString);
         PlayerPrefs.Save();
      }
}
