using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Saves : MonoBehaviour
{
    public TMP_Text saveDate;
    // Start is called before the first frame update
    string filePath;
    void Start()
    {
        filePath = Application.persistentDataPath + "StatsData.json";
    }

    private void Update()
    {
        saveDate.text = PlayerData.instance.GetDate();
    }

    public void LoadData()
    {
        if (System.IO.File.Exists(filePath))
        {
            Debug.Log("save");
            SceneManager.LoadScene("HubScene");
        }
        else
        {
            Debug.Log("No File Found");
            //play sound
        }
    }
}