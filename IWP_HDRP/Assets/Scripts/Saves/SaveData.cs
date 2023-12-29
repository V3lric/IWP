using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public Stats stats = new Stats();
    PlayerData data;
    private void Awake()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
    }
    public void SaveToJSON()
    {
        string statsData = JsonUtility.ToJson(stats);
        string filePath = Application.persistentDataPath + "/StatsData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, statsData);
        Debug.Log("Save Created");
    }

    public void LoadFromJSON()
    {
        string filePath = Application.persistentDataPath + "/StatsData.json";
        string statsData = System.IO.File.ReadAllText(filePath);
        stats = JsonUtility.FromJson<Stats>(statsData);
    }

    //public void SavingData()
    //{
    //    stats.Stage1 = data.Stage1;
    //    stats.Stage2 = data.Stage2;
    //    stats.StageBoss = data.StageBoss;
    //    stats.difficulty = data.GetDifficulty();
    //    stats.date = data.GetDate();
    //}
}


