using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject goal,block,reset;
    public bool touched = false;
    private Vector3 bLoc;

    // Start is called before the first frame update
    void Start()
    {
        bLoc = block.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (goal.GetComponent<Goal>().touched)
            touched = true;

        if (reset.GetComponent<ResetButton>().Reset)
        {
            Reset();
            reset.GetComponent<ResetButton>().Reset = false;
        }
    }

    public void Reset()
    {
        block.transform.position = bLoc;
    }
}
