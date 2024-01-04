using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShake : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            VCamShake.instance.CameraShakeVCam(4f, 1f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            VCamShake.instance.CameraShakeVCam(4f, 1f);
    }
}
