using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerRun : MonoBehaviour
{
    public static GameManagerRun Instance;
    [SerializeField] TMP_Text timerText;
    [SerializeField] float gameTimer;
    [SerializeField] GameObject floor,verticalJump, verticalJumpHard,deathUI;
    public bool win;
    Animator animator;
    public Animator gate;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        switch (PlayerData.instance.GetDifficulty())
        {
            case 0:
                gameTimer = 150f;
                verticalJump.SetActive(true);
                break;
            case 1:
                gameTimer = 120f;
                verticalJump.SetActive(true);
                break;
            case 2:
                gameTimer = 90f;
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
        if (!BossScript.instance.lose && !win)
        {
            gameTimer -= 1f * Time.deltaTime % 1f;
            float roundedTimer = UnityEngine.Mathf.Round(gameTimer);
            timerText.SetText("Time Left Before Collapse: " + roundedTimer.ToString() + "s");
        }
        else if (BossScript.instance.lose)
        {
            timerText.SetText("");
        }

        if (gameTimer < 0)
            BossScript.instance.lose = true;
    }
    public void HubScene()
    {
        SceneManager.LoadScene("HubScene");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            animator.SetTrigger("Fall");
        }
    }

}
