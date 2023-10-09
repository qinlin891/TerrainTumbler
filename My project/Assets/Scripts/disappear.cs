using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour
{
    private bool isVisible = true;

    void Start(){
        StartCoroutine(VisibilityRoutine());
    }

    IEnumerator VisibilityRoutine() {
        while(true) {
            yield return new WaitForSeconds(1);
            isVisible = !isVisible;
            GetComponent<Renderer>().enabled = isVisible;
        }
        yield return null;
    }
}
