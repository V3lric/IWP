using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class MissingSwitchManager : MonoBehaviour
{
    public static MissingSwitchManager Instance;
    public UnityEvent Cutscene;//invoke cutscene
    public GameObject[] Switches;
    public GameObject[] bPillar, pillar;
    public string SwitchTags,bColumn, column = "";
    public GameObject cp;
    public int currentIndex, numberOfSwitches = 0;
    public int switches,diff, iSwitchesPicked = 0;
    public bool completed, Solved = false;
    public List<bool> missingSwitchOrder = new List<bool>();
    List<GameObject> switchList = new List<GameObject>();
    List<GameObject> columnList = new List<GameObject>();
    List<GameObject> pColumnList = new List<GameObject>();
    GameManager manager;
    PlayerData data;

    void Start()
    {
        Instance = this;
        manager = GameObject.FindGameObjectWithTag("Game").GetComponent<GameManager>();
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
        diff = data.GetDifficulty();
        Transform parent = transform;
        //numberOfSwitches = Switch.Length;// Define the number of switches
        LocateSwitches(parent);
        LocatePillars(parent);
        GenerateSwitchOrder();
    }

    // Update is called once per frame
    void Update()
    {
        Difficulty();
        if (completed)
        {
            // Check if the switches are activated in the correct order
            if (currentIndex < missingSwitchOrder.Count)
            {
                SwitchSlot switchScript = Switches[currentIndex].GetComponent<SwitchSlot>();
                if (switchScript != null)
                {
                    if (missingSwitchOrder[currentIndex] == switchScript.isSwitched)
                    {
                        currentIndex++;
                    }
                    else
                    {
                        // Reset currentIndex to 0 when the wrong switch is flipped
                        currentIndex = 0;
                    }
                }
            }

            if (currentIndex == missingSwitchOrder.Count)
            {
                // Puzzle solved
                Debug.Log("Puzzle Solved!");
                Solved = true;
                currentIndex++;
                manager.CPIncrease();
                Cutscene.Invoke();
            }
        }
    }

    void Difficulty()
    {
        if (diff == 0 && switches == 3 && !completed)
        {
            manager.CPIncrease();
            completed = true;
        }
        else if (diff == 1 && switches == 3 && !completed)
        {
            manager.CPIncrease();
            completed = true;
        }
        else if (diff == 2 && switches == 4 && !completed)
        {
            manager.CPIncrease();
            completed = true;
        }
    }
    void LocateSwitches(Transform parent)
    {
        Transform[] allChildren = parent.GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            if (child.CompareTag(SwitchTags))
            {
                child.gameObject.GetComponent<SwitchSlot>().switchID = numberOfSwitches;
                switchList.Add(child.gameObject);
                numberOfSwitches++;
            }
        }

        // Assign the switches to the public Switch array
        Switches = switchList.ToArray();
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
        missingSwitchOrder.Clear();
        bool atLeastOneTrue = false;
        do
        {
            missingSwitchOrder.Clear(); // Clear the list at the beginning of each iteration
            for(int i = 0; i < missingSwitchOrder.Count; i++)
            {
                //Destroy(spawned);
            }
            for (int i = 0; i < numberOfSwitches; i++)
            {
                bool isSwitched = Random.Range(0, 2) == 0; // Randomly set switches to true or false
                missingSwitchOrder.Add(isSwitched);

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
        return missingSwitchOrder[order];
    }
}