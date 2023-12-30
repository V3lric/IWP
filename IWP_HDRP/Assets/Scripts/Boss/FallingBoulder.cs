using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBoulder : MonoBehaviour
{
    public GameObject boulder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("BoulderEndPt"))
        {
            Destroy(boulder);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(boulder);
        }
    }
}
