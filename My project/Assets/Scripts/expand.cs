using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expand : MonoBehaviour
{
    Vector3 targetScale = new Vector3(5.2f, 5.2f, 5.2f); 
    float minChangeInterval = 3.0f; 
    float maxChangeInterval = 5.0f; 
    float minReturnInterval = 1.0f;
    float maxReturnInterval = 2.0f; 

    private Vector3 originalScale;
    
    private void Start()
    {
        originalScale = transform.localScale; 
        StartCoroutine(ScaleObjectOverTime());
    }

    private IEnumerator ScaleObjectOverTime()
    {
        while (true)
        {
            float randomChangeInterval = Random.Range(minChangeInterval, maxChangeInterval);
            float randomReturnInterval = Random.Range(minReturnInterval, maxReturnInterval);

            yield return new WaitForSeconds(randomChangeInterval);
            transform.localScale = targetScale;

            yield return new WaitForSeconds(randomReturnInterval);
            transform.localScale = originalScale;
        }
    }
}
