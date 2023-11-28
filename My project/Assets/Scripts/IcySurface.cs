using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcySurface : MonoBehaviour
{
   float forceMagnitude = 4f;
   SpriteRenderer playerSpriteRenderer;

   void Start()
    {
    playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ice"))
        {
            Movement.isIcy = true;
            Rigidbody2D playerRigidbody = GetComponent<Rigidbody2D>();
            Vector2 forceDirection = playerSpriteRenderer.flipX ? Vector2.left : Vector2.right;
            playerRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ice"))
        {
            Movement.isIcy = false;
        }
    }
}
