using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingWall : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem particleBurst;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            animator.SetTrigger("Fall");
            StartCoroutine(Slam());
        }
    }

    IEnumerator Slam()
    {
        yield return new WaitForSeconds(1.5f);
        particleBurst.Play();
    }
}
