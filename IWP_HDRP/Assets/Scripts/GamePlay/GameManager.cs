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
    GameObject Spawn,Player;

    [Header("Objective UI")]
    [SerializeField] private List<GameObject> cpList = new List<GameObject>();
    [SerializeField] private int checkPoints, uiBubbleCP = -1;//no choice. default is 0 so will get out of bounds error if try to ref last cp
    public TextMeshProUGUI header, text;
    public string[] uiHeader, uiText;
    PlayerController pc;
    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Spawn = GameObject.FindGameObjectWithTag("Spawn");
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();

        cpList.Add(Spawn);
        text.text = uiText[checkPoints];
        header.text = uiHeader[checkPoints];
    }

    public void Stage1()
    {
        int diff = data.GetDifficulty();
        switch (diff)
        {
            case 0:
                Debug.Log("Ez");
                break;
            case 1:
                Debug.Log("Mid");
                break;
            case 2:
                Debug.Log("Hard");
                break;
            default:
                break;
        }
    }

    public void Stage2()
    {

    }

    public void ChestOpen()
    {
        
        data.Stage1 = true;
        //cutscene
        SceneManager.LoadScene("HubScene");
    }

    public void CPIncrease()
    {
        uiBubbleCP++;
        checkPoints++;

        text.text = uiText[checkPoints];
        header.text = uiHeader[checkPoints];
    }

    public Vector3 GetCheckPoint()
    {
        return cpList[checkPoints].transform.position;
    }

    public void AddCheckPoint(GameObject pos)
    {
        cpList.Add(pos);
    }
    public void SetDeath()
    {
        StartCoroutine(DeathSequence());
        Debug.Log("Death");
    }

    IEnumerator DeathSequence()
    {
        Vector3 checkpointPosition = GetCheckPoint();

        pc.disabled = true;//disable player controller if not player can't tp
        Player.transform.position = checkpointPosition;//overwrite player's pos if not cannot tp as player is still moving to intended pos
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = checkpointPosition;
        pc.disabled = false;
    }
}
