using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingGoal : MonoBehaviour
{
    public GameObject rLight, gLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            gLight.SetActive(true);
            rLight.SetActive(false);
        }
    }
}
