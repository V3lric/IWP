using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour
{
    public Rigidbody Block;
    public GameObject text;
    public string Player = "Player";
    public bool hit = false;
    Vector3 blkLoc;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Player))
        {
            hit = true;
            text.SetActive(true);

            Debug.Log("other2");
            blkLoc = other.transform.position;

            if (Input.GetKeyDown(KeyCode.E))
            {
                Block = other.GetComponent<Collider>().attachedRigidbody;

                Vector3 directionToBlock = other.gameObject.transform.position - transform.position;
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
                Block.AddForce((blkLoc + playerDirection) * 1f, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hit = false;
        text.SetActive(false);
    }
}
