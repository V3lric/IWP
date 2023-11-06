using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject escape,escapehud;
    [SerializeField] bool bEscape = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!bEscape)
            {
                escape.SetActive(true);
                escapehud.SetActive(false);
                bEscape = true;
            }
            else if (bEscape)
            {
                escape.SetActive(false);
                escapehud.SetActive(true);
                bEscape = false;
            }
        }
    }

    public void SaveExit()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
