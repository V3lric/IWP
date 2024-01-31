using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("hit");
        if (other.tag == "PBlocks")
            PPlateManager.instance.plateActivated = true;
    }
}
