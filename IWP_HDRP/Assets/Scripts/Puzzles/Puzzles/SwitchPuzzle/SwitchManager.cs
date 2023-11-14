using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class SwitchManager : MonoBehaviour
{
    public GameObject[] Switch;
    private int numberOfSwitches = 3; 
    public List<bool> switchOrder = new List<bool>();
    public string tags = "";
    public GameObject lDoor, rDoor;
    public int currentIndex = 0;
    public bool Solved = false;
    // Start is called before the first frame update
    GameManager manager;
    private float elapsedTime;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Game").GetComponent<GameManager>();
        Transform parent = transform;
        //numberOfSwitches = Switch.Length;// Define the number of switches
        LocateSwitches(parent);
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
            lDoor.SetActive(false);
            rDoor.SetActive(false);
            currentIndex++;
            manager.CPIncrease();
        }   
    }

    void LocateSwitches(Transform parent)
    {
        Transform[] allChildren = parent.GetComponentsInChildren<Transform>();
        List<GameObject> switchList = new List<GameObject>();

        foreach (Transform child in allChildren)
        {
            if (child.CompareTag(tags))
            {
                switchList.Add(child.gameObject);
            }
        }

        // Assign the switches to the public Switch array
        Switch = switchList.ToArray();
    }

    void GenerateSwitchOrder()
    {
        switchOrder.Clear();
        for (int i = 0; i < numberOfSwitches; i++)
        {
            bool isSwitched = Random.Range(0, 2) == 0; // Randomly set switches to true or false
            switchOrder.Add(isSwitched);
        }
    }
}
