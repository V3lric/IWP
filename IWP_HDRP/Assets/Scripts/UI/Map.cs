using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Map : MonoBehaviour
{
    private int currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HubScene()
    {
        if (currentScene != 0)
            SceneManager.LoadScene("HubScene");
    }
    public void Scene1()
    {
        if (currentScene != 1)
            SceneManager.LoadScene("Scene1");
    }
}
