using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlocks : MonoBehaviour
{
    private Rigidbody Block;
    public float forceMagnitude;
    public string Tag = "PBlocks";
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
        Block = hit.collider.attachedRigidbody;
        if (Block != null && hit.gameObject.CompareTag(Tag))
        {
            Vector3 direction = hit.gameObject.transform.position - transform.position;
            direction.Normalize();

            Vector3 directionLimit = Vector3.zero;

            // Check if player is on the right or left side
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
            {
                // Player is on the right side, move the block along the X-axis
                directionLimit = new Vector3(direction.x, 0f, 0f);
            }
            else
            {
                // Player is on the front or back side, move the block along the Z-axis
                directionLimit = new Vector3(0f, 0f, direction.z);
            }

            Block.AddForceAtPosition((directionLimit * forceMagnitude), transform.position, ForceMode.Impulse);
        }
    }
}
