using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerData : MonoBehaviour
{
    [SerializeField] int walkspeed = 100;
    [SerializeField] int talentPt, coins = 1;
    [SerializeField] string savedDate = "";
    [SerializeField] int difficulty = 0;
    // Start is called before the first frame update
    void Start()
    {
        //ensure theres one obj in each scene at all times
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Data");
        if (objs.Length > 1)
        {
            Debug.Log("More than 1 instance detected");
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDifficulty(int set)
    {
        difficulty = set;
    }

    public int GetDifficulty()
    {
        return difficulty;
    }

    public void SetDate()
    {
        savedDate = DateTime.Now.ToLongDateString().ToString();
    }

    public string GetDate()
    {
        return savedDate;
    }

    public int GetWalkSpeed()
    {
        return walkspeed;
    }
}
