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
    GameObject Spawn, Player;

    [Header("Puzzle GameObject")]
    public GameObject HardGate,boulderPuzzle;
    public GameObject switchPuzzle_mid, switchPuzzle_hard, missingPuzzle_mid, missingPuzzle_hard;//Switch puzzles
    public GameObject jumpPuzzle_easy, jumpPuzzle_mid, jumpPuzzle_hard;//jumping puzzles
    public GameObject circlePuzzle_easy, circlePuzzle_mid, circlePuzzle_hard;//circle puzzles

    [Header("Objective UI")]
    [SerializeField] private List<GameObject> cpList = new List<GameObject>();
    [SerializeField] private int checkPoints;//no choice. default is 0 so will get out of bounds error if try to ref last cp
    public int uiBubbleCP = -1;
    public TextMeshProUGUI header, text;
    public string[] uiHeader, uiText;
    PlayerController pc;
    ChatBubbleScript pet;

    private void Start()
    {
        pet = GameObject.FindGameObjectWithTag("ChatBubble").GetComponent<ChatBubbleScript>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Spawn = GameObject.FindGameObjectWithTag("Spawn");
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();

        cpList.Add(Spawn);
        text.text = uiText[checkPoints];
        header.text = uiHeader[checkPoints];
        Stages.Invoke();
    }

    public void Stage1()
    {
        int diff = data.GetDifficulty();
        switch (diff)
        {
            case 0:
                Debug.Log("Ez");
                switchPuzzle_mid.SetActive(true);
                missingPuzzle_mid.SetActive(true);
                jumpPuzzle_easy.SetActive(true);
                circlePuzzle_easy.SetActive(true);
                break;
            case 1:
                Debug.Log("Mid");
                switchPuzzle_mid.SetActive(true);
                missingPuzzle_mid.SetActive(true);
                jumpPuzzle_mid.SetActive(true);
                circlePuzzle_mid.SetActive(true);
                break;
            case 2:
                Debug.Log("Hard");
                switchPuzzle_hard.SetActive(true);
                missingPuzzle_hard.SetActive(true);
                jumpPuzzle_hard.SetActive(true);
                circlePuzzle_hard.SetActive(true);
                boulderPuzzle.SetActive(true);
                HardGate.SetActive(false);
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
        StartCoroutine(WinGameCutScene());
    }

    public void CPIncrease()
    {
        uiBubbleCP++;
        checkPoints++;
        pet.triggered = true;
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

    IEnumerator WinGameCutScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("HubScene");
    }
}
