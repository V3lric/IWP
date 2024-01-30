using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    public Stats stats = new Stats();
    [SerializeField] string savedDate;
    [SerializeField] int difficulty = 0;
    public bool Stage1, Stage2, StageBoss = false;

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
        instance = this;
        DontDestroyOnLoad(this.gameObject);
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

    public void SavingData()
    {
        stats.Stage1 = Stage1;
        stats.Stage2 = Stage2;
        stats.StageBoss = StageBoss;
        stats.difficulty = GetDifficulty();
        stats.date = GetDate();
    }

    public void LoadData()
    {
        savedDate = stats.date;
        Stage1 = stats.Stage1;
        Stage2 = stats.Stage2;
        StageBoss = stats.StageBoss;
        difficulty = stats.difficulty;
    }
    public void SaveToJSON()
    {
        SavingData();
        string statsData = JsonUtility.ToJson(stats);
        string filePath = "Assets/SaveFiles/StatsData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, statsData);
        Debug.Log("Save Created");
    }

    public void LoadFromJSON()//check if save file exists
    {
        string filePath = "Assets/SaveFiles/StatsData.json";
        string statsData = System.IO.File.ReadAllText(filePath);
        stats = JsonUtility.FromJson<Stats>(statsData);
        LoadData();
    }
}

[System.Serializable]
public class Stats
{
    public bool Stage1;
    public bool Stage2;
    public bool StageBoss;
    public int difficulty;
    public string date;
}