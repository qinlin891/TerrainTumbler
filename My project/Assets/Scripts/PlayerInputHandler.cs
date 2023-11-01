using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    Movement movement;
    

    void Awake() {
        movement = GetComponent<Movement>();
    }

    void Update(){
        if(Input.GetKey(KeyCode.A)){
            movement.Move(new Vector3(-1,0,0));
        }else if(Input.GetKey(KeyCode.D)){
            movement.Move(new Vector3(1,0,0));
        }else{
            movement.Stop();
        }
        if(Input.GetKeyDown(KeyCode.W)){
            movement.Jump();
        }
    }
}
