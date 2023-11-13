using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleTrigger : MonoBehaviour
{
    [SerializeField] GameObject icicle;

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && icicle != null)
        {
            Rigidbody2D icicleRb = icicle.GetComponent<Rigidbody2D>();
            icicleRb.gravityScale = 1;
        }
    }

}
