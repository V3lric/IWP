using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MissingSwitchManager : MonoBehaviour
{
    public GameObject[] Switches;
    private int numberOfSwitches = 3;
    public List<bool> missingSwitchOrder = new List<bool>();
    public string tags = "";
    public GameObject lDoor, rDoor;
    public int currentIndex = 0;
    public bool Solved = false;
    // Start is called before the first frame update
    GameManager manager;
    private float elapsedTime;
    public int switches = 0;
    public bool pickedUp = false;

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
        if (switches == 3)
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
                lDoor.SetActive(false);
                rDoor.SetActive(false);
                currentIndex++;
                manager.CPIncrease();
            }
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
        Switches = switchList.ToArray();
    }

    void GenerateSwitchOrder()
    {
        missingSwitchOrder.Clear();
        bool atLeastOneTrue = false;

        do
        {
            missingSwitchOrder.Clear(); // Clear the list at the beginning of each iteration

            for (int i = 0; i < numberOfSwitches; i++)
            {
                bool isSwitched = Random.Range(0, 2) == 0; // Randomly set switches to true or false
                missingSwitchOrder.Add(isSwitched);

                if (isSwitched)
                {
                    atLeastOneTrue = true;
                }
            }
        } while (!atLeastOneTrue);
    }
}
