using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("IcicleGround"))
        {
            Destroy(gameObject);
        }
    }
}
