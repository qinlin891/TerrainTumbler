using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;
    [SerializeField] float speed = 7f;
    [SerializeField] float jumpForce = 5;
    [SerializeField] LayerMask groundMask;

    private enum MovementState {idle, running, jumping, falling};
    

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        anim.SetInteger("state", (int)MovementState.idle);
    }

    public void Move(Vector3 mvec){
        MovementState state;
        state = MovementState.running;
        if(rb.velocity.y < -0.1f) {
            state = MovementState.falling;
        } else if(rb.velocity.y > 0.1f) {
             state = MovementState.jumping;
        } else if (mvec.x > 0) {
            sprite.flipX = false;
        } else if (mvec.x < 0) {
            sprite.flipX = true;
        } 

        mvec *= speed;
        mvec.y = rb.velocity.y;
        rb.velocity = mvec;

        anim.SetInteger("state", (int)state);
    }

    public void Stop(){
        if (Physics2D.OverlapCircleAll(transform.position - new Vector3(0, 0.5f, 0), 1, groundMask).Length > 0){
            anim.SetInteger("state", 0); 
        } else if(rb.velocity.y < -0.1f) {
            anim.SetInteger("state", 3);
        } else if(rb.velocity.y > 0.1f) {
             anim.SetInteger("state", 2);
        }
        rb.velocity = new Vector3(0,rb.velocity.y,0);
    }

    public void Jump() {
        anim.SetInteger("state", 2);

        if(Physics2D.OverlapCircleAll(transform.position-new Vector3(0,.5f,0),1,groundMask).Length > 0){
            rb.AddForce(new Vector3(0,jumpForce,0),ForceMode2D.Impulse);
        }
    }
}
