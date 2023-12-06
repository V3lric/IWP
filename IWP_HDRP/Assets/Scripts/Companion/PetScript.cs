using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetScript : MonoBehaviour
{
    public NavMeshAgent ai;
    public Transform player;
    public Animator aiAnim;
    Vector3 dest;

    void Update()
    {
        dest = player.position;
        ai.destination = dest;
        if (ai.remainingDistance <= ai.stoppingDistance)
        {
            //ai.destination = enemy.position + (transform.position - enemy.position).normalized * desiredDistance;
            //aiAnim.ResetTrigger("jog");
            //aiAnim.SetTrigger("idle");
        }
        else
        {
            //aiAnim.ResetTrigger("idle");
            //aiAnim.SetTrigger("jog");
        }
    }
}
