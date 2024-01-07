using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseStart : MonoBehaviour
{
    BossScript boss;
    public GameObject gate, player, pos;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bool once = false;
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && !once)
        {
            boss.PhaseBegin();
            once = true;
            gate.SetActive(true);
            StartCoroutine(TpPlayer());
        }
    }

    IEnumerator TpPlayer()
    {
        Vector3 newPosition = pos.transform.position;
        PlayerController.Instance.disabled = true;//disable player controller if not player can't tp
        player.transform.position = newPosition;//overwrite player's pos if not cannot tp as player is still moving to intended pos
        yield return new WaitForSeconds(0.1f);
        player.transform.position = newPosition;
        PlayerController.Instance.disabled = false;
    }
}
