using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObj : MonoBehaviour
{
    public GameObject Gate;
    bool destroyed = false;
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
        if (other.CompareTag("PCircles"))
        {
            Destroy(Gate);
            destroyed = true;
            //anim
        }
    }
}