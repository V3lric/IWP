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
        if ((transform.position - player.position).sqrMagnitude < ai.stoppingDistance * ai.stoppingDistance * 1f)//if pet is too close to player
        {
            ai.destination = transform.position + (transform.position - player.position).normalized;
            ai.stoppingDistance = 3;
            transform.forward = Vector3.Lerp(transform.forward, (player.position - transform.position).normalized, Time.deltaTime * 4);
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
