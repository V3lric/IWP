using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;
using UnityEngine.Events;
public class SwitchManager : MonoBehaviour
{
    public UnityEvent Cutscene;//invoke cutscene
    public GameObject[] Switch;
    public GameObject[] bPillar, pillar;
    private int numberOfSwitches = 0; 
    public List<bool> switchOrder = new List<bool>();
    public string SwitchTags, bColumn, column = "";
    public GameObject cp;
    public int currentIndex = 0;
    public bool Solved = false;
    // Start is called before the first frame update
    GameManager manager;
    private float elapsedTime;
    List<GameObject> columnList = new List<GameObject>();
    List<GameObject> pColumnList = new List<GameObject>();
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Game").GetComponent<GameManager>();
        Transform parent = transform;
        //numberOfSwitches = Switch.Length;// Define the number of switches
        LocateSwitches(parent);
        LocatePillars(parent);
        GenerateSwitchOrder();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the switches are activated in the correct order
        if (currentIndex < switchOrder.Count)
        {
            Switch switchScript = Switch[currentIndex].GetComponent<Switch>();
            if (switchScript != null)
            {
                if (switchOrder[currentIndex] == switchScript.isSwitched)
                {
                    currentIndex++;
                    AudioManager.Instance.PlaySFX("SwitchCorrect");
                }
                else
                {
                    // Reset currentIndex to 0 when the wrong switch is flipped
                    currentIndex = 0;
                }
            }
        }

        if (currentIndex == switchOrder.Count)
        {
            // Puzzle solved
            Debug.Log("Puzzle Solved!");
            Solved = true;
            currentIndex++;
            manager.CPIncrease();
            manager.AddCheckPoint(cp);
            Cutscene.Invoke();
        }   
    }

    void LocateSwitches(Transform parent)
    {
        Transform[] allChildren = parent.GetComponentsInChildren<Transform>();
        List<GameObject> switchList = new List<GameObject>();

        foreach (Transform child in allChildren)
        {
            if (child.CompareTag(SwitchTags))
            {
                switchList.Add(child.gameObject);
                numberOfSwitches++;
            }
        }

        // Assign the switches to the public Switch array
        Switch = switchList.ToArray();
    }
    void LocatePillars(Transform parent)
    {
        Transform[] allChildren = parent.GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            if (child.CompareTag(bColumn))
            {
                pColumnList.Add(child.gameObject);
            }

            if (child.CompareTag(column))
            {
                columnList.Add(child.gameObject);
            }
        }

        // Assign the switches to the public Switch array
        pillar = columnList.ToArray();
        bPillar = pColumnList.ToArray();
    }

    void GenerateSwitchOrder()
    {
        switchOrder.Clear();
        bool atLeastOneTrue = false;

        do
        {
            switchOrder.Clear(); // Clear the list at the beginning of each iteration

            for (int i = 0; i < numberOfSwitches; i++)
            {
                bool isSwitched = Random.Range(0, 2) == 0; // Randomly set switches to true or false
                switchOrder.Add(isSwitched);

                if (isSwitched)
                {
                    atLeastOneTrue = true;
                    pillar[i].SetActive(true);
                    bPillar[i].SetActive(false);
                }
                if (!isSwitched)
                {
                    pillar[i].SetActive(false);
                    bPillar[i].SetActive(true);
                }
            }
        } while (!atLeastOneTrue);
    }

    public bool GetSwitchOrder(int order)
    {
        return switchOrder[order];
    }
}
