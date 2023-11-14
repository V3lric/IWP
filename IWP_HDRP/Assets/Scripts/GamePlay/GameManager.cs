using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public UnityEvent Stages;
    [Header("Gameplay")]
    public bool puzzle1 = false;
    public bool puzzle2 = false;
    [Header("Objective UI")]
    [SerializeField] private GameObject[] cpTrigger;
    [SerializeField] private int checkPoints, uiBubbleCP = -1;//no choice. default is 0 so will get out of bounds error if try to ref last cp
    public TextMeshProUGUI header, text;
    public string[] uiHeader, uiText;

    private void Start()
    {
        cpTrigger = GameObject.FindGameObjectsWithTag("CP");
        Transform[] cpList;

        cpList = new Transform[cpTrigger.Length];

        for (int i = 0; i < cpTrigger.Length; i++)//find and store all cp inside list to ref pos ltr
        {
            cpList[i] = cpTrigger[i].transform;
        }
        text.text = uiText[checkPoints];
        header.text = uiHeader[checkPoints];
    }

    public void Stage1()
    {

    }

    public void Stage2()
    {

    }

    public void CPIncrease()
    {
        checkPoints++;
        uiBubbleCP++;

        Debug.Log(CheckPoint());
        text.text = uiText[checkPoints];
        header.text = uiHeader[checkPoints];
    }

    public Vector3 CheckPoint()
    {
        return cpTrigger[checkPoints].transform.position;
    }
    public void death()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = cpTrigger[checkPoints].transform.position;
    }
}
