using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenu : MonoBehaviour
{
    public GameObject setCam, dCam, saveCam;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
