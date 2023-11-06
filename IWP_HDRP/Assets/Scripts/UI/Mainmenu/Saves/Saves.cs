using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Saves : MonoBehaviour
{
    private PlayerData pData;
    public TMP_Text saveDate;
    // Start is called before the first frame update

    void Start()
    {
        pData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
        saveDate.text = pData.GetDate().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData()
    {
        SceneManager.LoadScene("HubScene");
    }
}