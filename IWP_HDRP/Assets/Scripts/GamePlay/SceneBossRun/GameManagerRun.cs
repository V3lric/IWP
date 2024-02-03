using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerRun : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float gameTimer;
    [SerializeField] GameObject floor,verticalJump, verticalJumpHard;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerData.instance.GetDifficulty())
        {
            case 0:
                gameTimer = 120f;
                verticalJump.SetActive(true);
                break;
            case 1:
                gameTimer = 90f;
                verticalJump.SetActive(true);
                break;
            case 2:
                gameTimer = 60f;
                verticalJumpHard.SetActive(true);
                break;
            default:
                break;
        }
        animator = floor.GetComponent<Animator>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            animator.SetTrigger("Fall");
        }
    }
}
