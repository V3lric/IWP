using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject map;
    private bool bmap = false;
    public GameObject escape, escapehud;
    public Slider MusicSlider, SFXSlider;
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
        if (Input.GetKeyDown("m"))
        {
            if (!bmap)
            {
                Enabled();
                map.SetActive(true);
                bmap = true;
            }
            else if (bmap)
            {
                Disabled();
                map.SetActive(false);
                bmap = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!bEscape)
            {
                Enabled();
                bEscape = true;
                escape.SetActive(true);
                escapehud.SetActive(false);
            }
            else if (bEscape)
            {
                Disabled();
                bEscape = false;
                escape.SetActive(false);
                escapehud.SetActive(true);
            }
        }
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVol()
    {
        AudioManager.Instance.MusicVol(MusicSlider.value);
    }

    public void SFXVol()
    {
        AudioManager.Instance.SFXVol(SFXSlider.value);
    }

    public void SetMusic(float Volumn)
    {
        MusicSlider.value = Volumn;
        AudioManager.Instance.MusicVol(MusicSlider.value);
    }

    public void SetSFX(float Volumn)
    {
        SFXSlider.value = Volumn;
        AudioManager.Instance.SFXVol(SFXSlider.value);
    }
    public void Enabled()
    {
        if (!bEscape || !bmap)
            player.disabled = true;
    }
    public void Disabled()
    {
        if (bEscape || bmap)
            player.disabled = false;
    }
    public void SaveExit()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
