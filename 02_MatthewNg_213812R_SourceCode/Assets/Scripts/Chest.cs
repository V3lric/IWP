using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour
{
    public UnityEvent Open;
    public string Player = "Player";
    public GameObject text;
    public bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hit)
            Open.Invoke();
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
