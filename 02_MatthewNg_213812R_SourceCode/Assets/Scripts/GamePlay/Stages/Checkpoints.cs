using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] GameManager gm;
    public bool hit = false;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Game").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && !hit)
        {
            gm.CPIncrease();
            gm.AddCheckPoint(gameObject);
            hit = true;
        }
    }
}
