using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTwo : MonoBehaviour
{
    Rigidbody2D rb;
     SpriteRenderer sprite;
    [SerializeField] float speed = 7f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Move(Vector3 mvec){
        mvec *= speed;
        rb.velocity = mvec;
        if (mvec.x > 0) {
            sprite.flipX = false;
        } else if (mvec.x < 0) {
            sprite.flipX = true;
        } 
    }

    public void Stop(){
        rb.velocity = new Vector3(0,rb.velocity.y,0);
    }
}
