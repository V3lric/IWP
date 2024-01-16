using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class Saves : MonoBehaviour
{
    private PlayerData pData;
    public TMP_Text saveDate;
    // Start is called before the first frame update

    void Start()
    {
        pData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();

    }

    // Update is called once per frame
    void Update()
    {
        if (System.IO.File.Exists("Assets/SaveFiles/StatsData.json"))
            saveDate.text = pData.stats.date.ToString();
    }

    public void LoadData()
    {
        if (System.IO.File.Exists("Assets/SaveFiles/StatsData.json"))
        {
            Debug.Log("save");
            pData.LoadFromJSON();
            SceneManager.LoadScene("HubScene");
        }
        else
        {
            Debug.Log("No File Found");
            //play sound
        }
    }
}