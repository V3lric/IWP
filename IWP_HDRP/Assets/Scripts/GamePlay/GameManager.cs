using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay")]
    public UnityEvent Stages;
    public bool puzzle1, puzzle2 = false;
    PlayerData data;

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

    public void ChestOpen()
    {
        PlayerData data = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
        data.Stage1 = true;
        //cutscene
        SceneManager.LoadScene("HubScene");
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
