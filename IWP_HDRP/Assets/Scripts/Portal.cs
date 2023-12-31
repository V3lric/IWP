using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject map;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            map.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            map.SetActive(false);
    }
}
