using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float Speed = 3f;
    private Vector3 pos;

    void Start() {
        pos = pointA.position;
    }

    void Update() {
        if(Vector3.Distance(transform.position, pointA.position) < .1f) {
            pos = pointB.position;
        }
        if(Vector3.Distance(transform.position, pointB.position) < .1f) {
            pos = pointA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player") {
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "Player") {
            other.gameObject.transform.SetParent(null);
        }
    }

}
