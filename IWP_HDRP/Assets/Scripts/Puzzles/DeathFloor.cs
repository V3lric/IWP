using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    public GameObject respawn,Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            StartCoroutine(DeathSequence());
    }
    IEnumerator DeathSequence()
    {
        Vector3 checkpointPosition = respawn.transform.position;

        PlayerController.Instance.disabled = true;//disable player controller if not player can't tp
        Player.transform.SetPositionAndRotation(checkpointPosition, Quaternion.identity);//overwrite player's pos if not cannot tp as player is still moving to intended pos
        yield return new WaitForSeconds(0.2f);
        Player.transform.SetPositionAndRotation(checkpointPosition,Quaternion.identity);
        PlayerController.Instance.disabled = false;
    }
}
