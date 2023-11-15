using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    Movement movement;
    [SerializeField] GameObject pause;
    

    void Awake() {
        movement = GetComponent<Movement>();
    }

    void Update(){
        if(!Timer.singleton.IsPaused()) {
            if(Input.GetKey(KeyCode.A)){
                movement.Move(new Vector3(-1,0,0));
            } else if(Input.GetKey(KeyCode.D)){
                movement.Move(new Vector3(1,0,0));
            } else{
                movement.Stop();
            }
            if(Input.GetKeyDown(KeyCode.W)){
                movement.Jump();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.Stop();
            Timer.singleton.PauseTimer();
            pause.SetActive(true);
        }
        
    }
}
