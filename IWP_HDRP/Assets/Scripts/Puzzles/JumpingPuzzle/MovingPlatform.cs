using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform start, end;
    [SerializeField] float changeDirDelay;
    private Transform destTarget, departTarget;
    private float startTime,journeyLength;
    bool isWaiting;
    // Start is called before the first frame update
    void Start()
    {
        departTarget = start;
        destTarget = end;

        startTime = Time.time;
        journeyLength = Vector3.Distance(departTarget.position,destTarget.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (!isWaiting)
        {
            if (Vector3.Distance(transform.position, destTarget.position) > 0.01f)
            {
                float distCovered = (Time.time - startTime) * speed;

                float fractionOfJourney = distCovered / journeyLength;

                transform.position = Vector3.Lerp(departTarget.position, destTarget.position, fractionOfJourney);
            }
            else
            {
                isWaiting = true;
                StartCoroutine(ChangeDelay());
            }
        }
    }

    void ChangeDestination()
    {
        if (departTarget == end && destTarget == start)
        {
            departTarget = start;
            destTarget = end;
        }
        else
        {
            departTarget = end;
            destTarget = start;
        }
    }
    IEnumerator ChangeDelay()
    {
        yield return new WaitForSeconds(changeDirDelay);
        ChangeDestination();
        startTime = Time.time;
        journeyLength = Vector3.Distance(departTarget.position, destTarget.position);
        isWaiting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            other.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            other.transform.parent= null;
    }
}
