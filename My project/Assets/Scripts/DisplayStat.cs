using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStat : MonoBehaviour
{
     [SerializeField] Text Time;
     [SerializeField] Text Shards;

     void Start() {
        Shards.text = "x " + GameManager.singleton.GetTotalShards();
        Time.text = "Time Used: " + GameManager.singleton.GetFormatTime();
     }
}
