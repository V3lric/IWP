using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CineMachineShakeEffect.Instance.CameraShake(4f, 0.5f);
        }
    }
}
