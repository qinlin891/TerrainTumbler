using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectPoint : MonoBehaviour
{
    [SerializeField] Text score;
    private int point = 0;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("shard")) {
            Destroy(other.gameObject);
            point++;
            score.text = point.ToString();
            GetComponent<AudioSource>().Play();
        }
    }

    public int GetPoint() {
        return point;
    }
}
