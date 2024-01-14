using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCircles : MonoBehaviour
{
    private Rigidbody Circle;
    public float forceMagnitude;
    public string Tag = "PCircles";
    public Animator animator;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Circle = hit.collider.attachedRigidbody;
        if (Circle != null && hit.gameObject.CompareTag(Tag))
        {
            Vector3 direction = hit.gameObject.transform.position - transform.position;
            direction.Normalize();
            Circle.AddForceAtPosition(direction * forceMagnitude, transform.position, ForceMode.Force);
            animator.SetFloat("Player", 3f, 0.01f, Time.deltaTime);
        }
    }
}
