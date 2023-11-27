using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject map;
    private bool bmap = false;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            if (!bmap)
            {
                map.SetActive(true);
                bmap = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (bmap)
            {
                map.SetActive(false);
                bmap = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
