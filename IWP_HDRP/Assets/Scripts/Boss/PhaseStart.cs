using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseStart : MonoBehaviour
{
    BossScript boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            boss.PhaseBegin();
        }
    }
}
