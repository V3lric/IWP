using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateClose : MonoBehaviour
{
    bool once;
    public GameObject dead;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && !once)
        {
            GameManagerRun.Instance.gate.SetTrigger("Tigger");
            once = true;
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(6f);
        dead.SetActive(true);
    }
}
