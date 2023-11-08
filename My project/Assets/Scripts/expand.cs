using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expand : MonoBehaviour
{
    Vector3 targetScale = new Vector3(5.2f, 5.2f, 5.2f); // Change this to the desired target scale.
    float minChangeInterval = 3.0f; // Minimum change interval.
    float maxChangeInterval = 5.0f; // Maximum change interval.
    float minReturnInterval = 1.0f; // Minimum return interval.
    float maxReturnInterval = 2.0f; // Maximum return interval.

    private Vector3 originalScale;
    
    private void Start()
    {
        originalScale = transform.localScale; // Store the original scale.
        StartCoroutine(ScaleObjectOverTime());
    }

    private IEnumerator ScaleObjectOverTime()
    {
        while (true)
        {
            // Generate random change and return intervals within specified ranges.
            float randomChangeInterval = Random.Range(minChangeInterval, maxChangeInterval);
            float randomReturnInterval = Random.Range(minReturnInterval, maxReturnInterval);

            // Expand to the target scale after the random changeInterval.
            yield return new WaitForSeconds(randomChangeInterval);
            transform.localScale = targetScale;

            // Return to the original scale after the random returnInterval.
            yield return new WaitForSeconds(randomReturnInterval);
            transform.localScale = originalScale;
        }
    }
}
