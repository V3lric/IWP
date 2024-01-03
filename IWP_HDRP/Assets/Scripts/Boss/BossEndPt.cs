using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEndPt : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            BossScript.instance.WinGame();
        }
    }
}
