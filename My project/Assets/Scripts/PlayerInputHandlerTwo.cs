using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandlerTwo : MonoBehaviour
{
    MovementTwo movement;

    void Awake() {
        movement = GetComponent<MovementTwo>();
    }

    void Update(){
        if(Input.GetKey(KeyCode.A)){
            movement.Move(new Vector3(-1,-0.2f,0));
        }else if(Input.GetKey(KeyCode.D)){
            movement.Move(new Vector3(1,-0.2f,0));
        }else if(Input.GetKey(KeyCode.W)) {
            movement.Move(new Vector3(0,1,0));
        }
        else{
            movement.Stop();
        }
    }
}
