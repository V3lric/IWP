using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Map : MonoBehaviour
{
    PlayerData data;
    [SerializeField] GameObject home, stage1, stage2, sceneboss;
    [SerializeField] string scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
        switch (scene)
        {
            case "HubScene":
                home.SetActive(true);
                break;
            case "Stage1":
                stage1.SetActive(true);
                break;
            case "Stage2":
                stage2.SetActive(true);
                break;
            case "BossScene":
                sceneboss.SetActive(true);
                break;
            case "BossRunScene":
                sceneboss.SetActive(true);
                break;
            default:
                break;
        }
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
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Stage1"))
        {
            SceneManager.LoadScene("Stage1");
            AudioManager.Instance.PlaySound("Stage1");
        }
        else
        {
            //play error sound
        }
    }

    public void Scene2()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Stage2") && data.Stage1)
        {
            SceneManager.LoadScene("Stage2");
            AudioManager.Instance.PlaySound("Stage2");
        }
        else
        {
            //play error sound
        }
    }

    public void Scene3()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("BossScene") && data.Stage2)
        {
            SceneManager.LoadScene("BossScene");
            AudioManager.Instance.PlaySound("Stage3");
        }
        else
        {
            //play error sound
        }
    }
}
