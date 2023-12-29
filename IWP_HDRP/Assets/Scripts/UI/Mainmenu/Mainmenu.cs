using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject setCam, dCam, saveCam;
    private PlayerData pData;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        dCam.SetActive(true);
    }

    public void SettingButton()
    {
        setCam.SetActive(true);
    }
    public void SaveButton()
    {
        saveCam.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        dCam.SetActive(false);
        setCam.SetActive(false);
        saveCam.SetActive(false);
    }

    public void SetEasy()
    {
        pData.SetDifficulty(0);
        pData.SetDate();
        SceneManager.LoadScene("PreTutCutscene");
    }
    public void SetMed()
    {
        pData.SetDifficulty(1);
        pData.SetDate();
        SceneManager.LoadScene("PreTutCutscene");
    }

    public void SetHard()
    {
        pData.SetDifficulty(2);
        pData.SetDate();
        SceneManager.LoadScene("PreTutCutscene");
    }
}
