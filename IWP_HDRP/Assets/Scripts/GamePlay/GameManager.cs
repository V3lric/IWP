using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnityEvent Stages;
    [SerializeField] private GameObject[] Switch;
    [SerializeField] private int Checkpoints, UIBubbleCP = -1;//no choice. default is 0 so will get out of bounds error if try to ref last cp

    private void Start()
    {
        Switch = GameObject.FindGameObjectsWithTag("CP");
        Transform[] switchlist;

        switchlist = new Transform[Switch.Length];

        for (int i = 0; i < Switch.Length; i++)//find and store all cp inside list to ref pos ltr
        {
            switchlist[i] = Switch[i].transform;
        }
    }
    public void Stage1()
    {

    }

    public void Stage2()
    {

    }

    public void CPIncrease()
    {
        Checkpoints++;
        UIBubbleCP++;

        Debug.Log(CheckPoint());
        Debug.Log(Switch.Length);
    }

    public Vector3 CheckPoint()
    {
        return Switch[Checkpoints].transform.position;
    }
}
