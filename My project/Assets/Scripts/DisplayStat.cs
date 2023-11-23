using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStat : MonoBehaviour
{
      [SerializeField] Text Time;
      [SerializeField] Text Shards;
      [SerializeField] Text Score;

      private const string TOP_SCORES_KEY = "TopScores";
      private const int MAX_TOP_SCORES = 3;
      private List<int> topScores;

      void Awake() {
        LoadTopScores();
      }

      void Start() {
         Shards.text = "x " + GameManager.singleton.GetTotalShards();
         Time.text = "Time Used: " + GameManager.singleton.GetFormatTime();
         int timeInSeconds = GameManager.singleton.GetTimeInSec();
         int shardsCollected = int.Parse(GameManager.singleton.GetTotalShards());
         int newScore = CalculateScore(timeInSeconds, shardsCollected);
         Score.text = "Score: " + newScore.ToString();
         AddScore(newScore);
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

      private int CalculateScore(int timeInSeconds, int shardsCollected) {
         float timeWeight = 0.7f; 
         float shardsWeight = 0.3f;

         float normalizedTime = Mathf.Clamp01(1.0f - timeInSeconds / 600.0f);
         float normalizedShards = Mathf.Clamp01((float)shardsCollected / 31); 

         float finalScore = (normalizedTime * timeWeight + normalizedShards * shardsWeight) * 1000.0f; // Adjust scaling as needed
         return Mathf.RoundToInt(finalScore);
      }
}
