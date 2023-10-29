using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTwo : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 7f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 mvec){
        mvec *= speed;
        rb.velocity = mvec;
    }

    public void Stop(){
        rb.velocity = new Vector3(0,rb.velocity.y,0);
    }
}
