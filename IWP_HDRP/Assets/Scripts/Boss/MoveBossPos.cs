using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBossPos : MonoBehaviour
{
    [SerializeField] float yAxisPos;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.tag == "Boss")
            BossScript.instance.ChangeYPos(18.6f);
    }
}
