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

    void FixedUpdate()
    {
        dest = new Vector3(player.position.x + 2, player.position.y, player.position.z);
        float distanceToPlayer = (transform.position - player.position).magnitude;
        if (distanceToPlayer < ai.stoppingDistance)
            aiAnim.SetFloat("Pet", 0f);
        if (distanceToPlayer < ai.stoppingDistance -1)
        {
            // Player is too close, make the pet walk backward
            Vector3 reverseDirection = transform.position - player.position;
            Vector3 backwardDestination = transform.position + reverseDirection.normalized * 3; // Adjust the distance as needed

            // Move the pet backward gradually
            ai.destination = Vector3.Lerp(ai.destination, backwardDestination, Time.deltaTime * 4); // Adjust the factor for smoother movement

            // Rotate the pet to face away from the player
            //transform.forward = Vector3.Lerp(transform.forward, -reverseDirection.normalized, Time.deltaTime * 4);
            transform.LookAt(player);
            aiAnim.SetFloat("Pet", 0f,0.1f,Time.deltaTime);
            // aiAnim.ResetTrigger("jog");
            // aiAnim.SetTrigger("walkBackward");
        }
        else if (distanceToPlayer >= (ai.stoppingDistance))
        {
            // Player is at a normal distance, move toward the player
            ai.destination = dest;

            // Rotate the pet to face the player
            transform.forward = Vector3.Lerp(transform.forward, (player.position - transform.position).normalized, Time.deltaTime * 4);
            aiAnim.SetFloat("Pet",1f, 0.1f, Time.deltaTime);
            // aiAnim.ResetTrigger("walkBackward");
            // aiAnim.SetTrigger("jog");
        }
        else if (distanceToPlayer > 6)
            transform.position = dest;
    }
}
