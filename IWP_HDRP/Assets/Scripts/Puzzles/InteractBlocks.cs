using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBlocks : MonoBehaviour
{
    private Rigidbody Block;
    public float forceMagnitude;
    public string Tag = "IBlocks";
    Vector3 blkLoc;
    InteractUI UI;

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
        GameObject other = hit.gameObject;

        if (hit.gameObject.CompareTag(Tag))
        {
            blkLoc = hit.transform.position;

            if (Input.GetKeyDown(KeyCode.E))
            {
                Block = hit.collider.attachedRigidbody;

                Vector3 directionToBlock = hit.gameObject.transform.position - transform.position;
                Vector3 playerDirection = Vector3.zero;

                // Calculate player's position relative to the block
                if (Mathf.Abs(directionToBlock.x) > Mathf.Abs(directionToBlock.z))
                {
                    // Player is more to the left or right of the block
                    playerDirection = new Vector3(Mathf.Sign(directionToBlock.x), 0, 0);
                }
                else
                {
                    // Player is more above or below the block
                    playerDirection = new Vector3(0, 0, Mathf.Sign(directionToBlock.z));
                }
                Block.AddForce((blkLoc+ playerDirection) * forceMagnitude, ForceMode.Impulse);
            }
        }
    }
}
