using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    GameManager manager;
    public GameObject respawn, Player,shaking;
    PlayerController pc;
    float timer = 20f;
    AudioSource Sfx;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Player = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.FindGameObjectWithTag("Game").GetComponent<GameManager>();
        respawn = GameObject.FindGameObjectWithTag("RespawnCube");
        //Sfx.outputAudioMixerGroup = AudioManager.Instance.sfxSource.outputAudioMixerGroup;
    }
    private void Update()
    {
        timer -= Time.deltaTime * 1f;
        if (timer < 0)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DeathSequence());
        }
    }

    IEnumerator DeathSequence()
    {
        Vector3 checkpointPosition = respawn.transform.position;

        pc.disabled = true;//disable player controller if not player can't tp
        Player.transform.position = checkpointPosition;//overwrite player's pos if not cannot tp as player is still moving to intended pos
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = checkpointPosition;
        pc.disabled = false;
    }
}
