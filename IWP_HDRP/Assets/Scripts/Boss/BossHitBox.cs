using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //restart
            Debug.Log("hit");
        }
    }
}