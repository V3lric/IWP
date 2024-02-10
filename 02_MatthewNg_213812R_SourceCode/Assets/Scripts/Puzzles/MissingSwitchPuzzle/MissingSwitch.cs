using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingSwitch : MonoBehaviour
{
    public string Player = "Player";
    public GameObject text, switches;
    public bool isSwitched, hit = false;
    MissingSwitchManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("SwitchPuzzle").GetComponent<MissingSwitchManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hit)
        {
            switches.SetActive(false);
            manager.iSwitchesPicked++;
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
