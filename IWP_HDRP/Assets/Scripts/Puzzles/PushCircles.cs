using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCircles : MonoBehaviour
{
    private Rigidbody Circle;
    public float forceMagnitude;
    public string Tag = "PCircles";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Circle = hit.collider.attachedRigidbody;
        if (Circle != null && hit.gameObject.CompareTag(Tag))
        {
            Vector3 direction = hit.gameObject.transform.position - transform.position;
            direction.Normalize();
            Circle.AddForceAtPosition(direction * forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}
