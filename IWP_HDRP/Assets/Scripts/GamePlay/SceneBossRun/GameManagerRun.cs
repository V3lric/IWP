using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerRun : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float gameTimer;
    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerData.instance.GetDifficulty())
        {
            case 0:
                gameTimer = 120f;
                break;
            case 1:
                gameTimer = 90f;
                break;
            case 2:
                gameTimer = 60f;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= 1f * Time.deltaTime % 1f;
        float roundedTimer = UnityEngine.Mathf.Round(gameTimer);
        timerText.SetText("Time Left Before Collapse: "+roundedTimer.ToString()+"s");
        if (gameTimer < 0)
        {
            //gameover ui
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
