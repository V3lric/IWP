using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObj : MonoBehaviour
{
    public GameObject Gate,rLight, gLight;
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
            gLight.SetActive(true);
            rLight.SetActive(false);
            DialogManager.instance.CustomText("Nice! Looks like there was a switch behind the gate.", "Truffle");
        }
    }
}
