using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossCamLock : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController thePlayer;

    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        lastPlayerPosition = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = thePlayer.transform.position.y - lastPlayerPosition.y;

        transform.position = new Vector3(transform.position.x, transform.position.y + distanceToMove, transform.position.z);

        lastPlayerPosition = thePlayer.transform.position;
    }
}
