using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    GameManager manager;
    public GameObject respawn,Player;
    PlayerController pc;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            //manager.SetDeath();
            StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        Vector3 checkpointPosition = respawn.transform.position;

        pc.disabled = true;//disable player controller if not player can't tp
        Player.transform.position = checkpointPosition;//overwrite player's pos if not cannot tp as player is still moving to intended pos
        yield return new WaitForSeconds(0.1f);
        Player.transform.position = checkpointPosition;
        pc.disabled = false;
    }
}
