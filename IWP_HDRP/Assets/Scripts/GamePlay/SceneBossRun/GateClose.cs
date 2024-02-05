using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateClose : MonoBehaviour
{
    bool once;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && !once)
        {
            GameManagerRun.Instance.gate.SetTrigger("Tigger");
            GameManagerRun.Instance.win = true;
            once = true;
        }
    }
}
