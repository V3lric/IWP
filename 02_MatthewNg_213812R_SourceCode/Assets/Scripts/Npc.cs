using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private float timer;

    [SerializeField] Animator animator;
    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        animator.SetFloat("Brown", 0f, 0.1f, Time.deltaTime);
        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            
            timer = 0;
        }
        if (timer < 1) 
            animator.SetFloat("Brown", 1f, 0.01f,Time.deltaTime);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        UnityEngine.AI.NavMeshHit navHit;

        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
