using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public string Player = "Player";
    public GameObject text;
    public bool isSwitched,hit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hit)
        {
            if (!isSwitched)
                isSwitched = true;
            else if (isSwitched)
                isSwitched = false;
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
        hit = true;
    }
    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
        hit = false;
    }
}
