using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public GameObject platform;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = platform.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StartCoroutine(Falling());
            Debug.Log("falling");
        }
    }

    IEnumerator Falling()
    {
        
        //insert rumbling anim 
        yield return new WaitForSeconds(1.5f);
        rb.useGravity = true;
    }
}
