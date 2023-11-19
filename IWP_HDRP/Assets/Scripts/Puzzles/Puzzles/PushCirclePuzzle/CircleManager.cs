using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    public GameObject goal, circle, reset;
    public bool touched = false;
    private Vector3 cLoc;

    // Start is called before the first frame update
    void Start()
    {
        cLoc = circle.transform.position;
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
        circle.transform.position = cLoc;
    }
}
