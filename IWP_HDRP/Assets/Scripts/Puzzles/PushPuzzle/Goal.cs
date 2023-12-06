using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool touched;
    private string Tag1 = "PBlocks";
    private string Tag2 = "PCircles";
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
        GameObject hit = other.gameObject;
        if (hit.gameObject.CompareTag(Tag1) || hit.gameObject.CompareTag(Tag2))
        {
            touched = true;
        }
    }
}
