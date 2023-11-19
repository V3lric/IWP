using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public GameObject[] Lock;
    private int numberOfLock = 3;
    public List<int> lockOrder = new List<int>();
    public string tags = "Lock"; // Corrected the variable name for the tag
    public int currentIndex = 0;
    public bool Solved = false;

    // Start is called before the first frame update
    void Start()
    {
        Transform parent = transform;
        LocateLocks(parent);
        GenerateLockOrder();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentIndex < lockOrder.Count)
        {
            Lock lockScript = Lock[currentIndex].GetComponent<Lock>();

            if (lockScript != null)
            {
                if (lockScript.currentImg == lockOrder[currentIndex])
                {
                    currentIndex++;
                }
                else
                {
                    // Reset currentIndex to 0 when the wrong lock is not in the correct order
                    currentIndex = 0;
                }
            }
        }

        if (currentIndex == lockOrder.Count)
        {
            // Puzzle solved
            Debug.Log("Puzzle Solved!");
            Solved = true;
        }
    }

    void LocateLocks(Transform parent)
    {
        Transform[] allChildren = parent.GetComponentsInChildren<Transform>();
        List<GameObject> lockList = new List<GameObject>();

        foreach (Transform child in allChildren)
        {
            if (child.CompareTag(tags)) // Use the correct tag variable
            {
                lockList.Add(child.gameObject);
            }
        }

        // Assign the locks to the public Lock array
        Lock = lockList.ToArray();
    }

    void GenerateLockOrder()//havent fix yet
    {
        lockOrder.Clear();
        for (int i = 0; i < numberOfLock; i++)
        {
            int ranInt = Random.Range(0, 4); // Generate random values for the lock order
            lockOrder.Add(ranInt);
        }
    }
}
