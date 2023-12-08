using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Falling());
    }

    IEnumerator Falling()
    {
        //insert rumbling anim 
        yield return new WaitForSecondsRealtime(2f);
        rb.useGravity = true;
    }
}
