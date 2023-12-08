using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractUIBubble : MonoBehaviour
{
    [SerializeField] Transform vCamTransform;
    // Start is called before the first frame update
    void Start()
    {
        vCamTransform = GameObject.FindGameObjectWithTag("VCam").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(vCamTransform);
    }
}
