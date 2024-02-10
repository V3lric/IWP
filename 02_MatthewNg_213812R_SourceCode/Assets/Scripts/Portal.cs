using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public UIManager manager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            manager.Portal();
    }
}
