using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRunLava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            BossScript.instance.lose = true;
    }
}
