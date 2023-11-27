using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject escape,escapehud;
    [SerializeField] bool bEscape = false;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
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
                player.disabled = true;
            }
            else if (bEscape)
            {
                escape.SetActive(false);
                escapehud.SetActive(true);
                bEscape = false;
                player.disabled = false;
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
