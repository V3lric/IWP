using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Map : MonoBehaviour
{
    PlayerData data;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HubScene()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("HubScene"))
        {
            SceneManager.LoadScene("HubScene");
            AudioManager.Instance.PlaySound("MainMenu");
        }
        else
        {
            //play error sound
        }
    }
    public void Scene1()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Scene1"))
        {
            SceneManager.LoadScene("Scene1");
            AudioManager.Instance.PlaySound("Scene1");
        }
        else
        {
            //play error sound
        }
    }

    public void Scene2()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Scene2") && !data.Stage1)
        {
            SceneManager.LoadScene("Scene2");
        }
        else
        {
            //play error sound
        }
    }

    public void Scene3()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("SceneBoss") && !data.Stage2)
        {
            SceneManager.LoadScene("SceneBoss");
        }
        else
        {
            //play error sound
        }
    }
}
