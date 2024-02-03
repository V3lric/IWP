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
    public bool lose = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
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
        if (!lose)
        {
            gameTimer -= 1f * Time.deltaTime % 1f;
            float roundedTimer = UnityEngine.Mathf.Round(gameTimer);
            timerText.SetText("Time Left Before Collapse: " + roundedTimer.ToString() + "s");
        }
        else if (lose)
        {
            PlayerController.Instance.disabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            deathUI.SetActive(true);
            timerText.SetText("");
        }

        if (gameTimer < 0)
            lose = true;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        PlayerData.instance.SaveToJSON();
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        PlayerData.instance.SaveToJSON();
        Application.Quit();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            animator.SetTrigger("Fall");
        }
    }
}
