using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSlot : MonoBehaviour
{
    public string Player = "Player";
    public GameObject text, switches;
    public bool isSwitched, hit, done = false;
    MissingSwitchManager manager;
    GameManager game;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("SwitchPuzzle").GetComponent<MissingSwitchManager>();
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hit)
        {
            if (manager.pickedUp)
            {
                switches.SetActive(true);
                manager.switches++;
                manager.pickedUp = false;
                done = true;
                game.CPIncrease();
            }
            if (done)
            {
                if (!isSwitched)
                    isSwitched = true;
                else if (isSwitched)
                    isSwitched = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Player))
        {
            text.SetActive(true);
            hit = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Player))
            hit = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Player))
        {
            text.SetActive(false);
            hit = false;
        }
    }
}
