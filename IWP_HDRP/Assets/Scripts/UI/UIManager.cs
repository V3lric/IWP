using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject map,portal;
    private bool bmap = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
            }
            else if (bmap)
            {
                map.SetActive(false);
                bmap = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        map.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        map.SetActive(false);
    }
}
