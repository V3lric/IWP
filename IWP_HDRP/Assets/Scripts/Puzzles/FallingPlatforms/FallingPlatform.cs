using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public GameObject platform;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
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
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("fall");
    }
}
