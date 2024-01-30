using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBossPos : MonoBehaviour
{
    [SerializeField] float yAxisPos;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Boss"))
            BossScript.instance.ChangeYPos(18.6f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
        if (other.gameObject.layer == LayerMask.NameToLayer("Boss"))
            BossScript.instance.ChangeYPos(18.6f);
    }
}
