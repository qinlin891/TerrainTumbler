using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanController : MonoBehaviour
{
    public GameObject snowballPrefab;
    public Transform playerTransform;
    public float throwInterval = 0.5f; 

    private float lastThrowTime;
    private bool playerInsideZone = false;

   
    private static List<GameObject> snowballPool;
    int poolMax = 5; 

    void Start()
    {
        if (snowballPool == null)
        {
            snowballPool = new List<GameObject>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideZone = true;
            StartContinuousThrowing();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideZone = false;
        }
    }

    void StartContinuousThrowing()
    {
        StartCoroutine(ContinuousThrowing());
    }

    void StopContinuousThrowing()
    {
        StopAllCoroutines();
    }

    IEnumerator ContinuousThrowing()
    {
        while (playerInsideZone)
        {
            yield return new WaitForSeconds(throwInterval);
            ThrowSnowball();
        }
    }

    void ThrowSnowball()
    {
        GameObject newSnowball = GetSnowballFromPool();

        if (newSnowball == null)
        {
            newSnowball = InstantiateSnowball();
        }

        newSnowball.transform.position = transform.position;
        newSnowball.transform.rotation = Quaternion.identity;

        newSnowball.SetActive(true);

        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

        float throwDirection = Mathf.Sign(directionToPlayer.x);

        newSnowball.GetComponent<Rigidbody2D>().velocity = new Vector2(throwDirection * 10f, 0f);

        StartCoroutine(DeactivateSnowballRoutine(newSnowball));
    }

    GameObject GetSnowballFromPool()
    {
        for (int i = 0; i < snowballPool.Count; i++)
        {
            if (!snowballPool[i].activeInHierarchy)
            {
                return snowballPool[i];
            }
        }

        return null;
    }

    GameObject InstantiateSnowball()
    {
        GameObject snowball = Instantiate(snowballPrefab);
        snowball.SetActive(false);

        snowballPool.Add(snowball);

        if (snowballPool.Count > poolMax)
        {
            GameObject oldestSnowball = snowballPool[0];
            snowballPool.RemoveAt(0);
            Destroy(oldestSnowball);
        }

        return snowball;
    }

    IEnumerator DeactivateSnowballRoutine(GameObject snowball)
    {
        yield return new WaitForSeconds(2f);

        snowball.SetActive(false);
    }

    public static void ClearSnowballPool()
    {
        foreach (var snowball in snowballPool)
        {
            if (snowball != null)
            {
                Destroy(snowball);
            }
        }
        snowballPool.Clear();
    }
}
