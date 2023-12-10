using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject map;
    public GameObject escape, escapehud;
    public GameObject mTrue, mFalse;//music icon
    public GameObject eTrue, eFalse;//escape icon
    public GameObject stage1T, stage1F;
    [SerializeField] bool music,sfx = false;
    public Slider MusicSlider, SFXSlider;
    [SerializeField] bool bEscape, bmap = false;//enable if either one is active and disable if both is not active
    PlayerController player;
    PlayerData data;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        MusicSlider.value = AudioManager.Instance.musicSource.volume;
        SFXSlider.value = AudioManager.Instance.sfxSource.volume;

        if (data.Stage1)
        {
            stage1T.SetActive(true);
            stage1F.SetActive(false);
        }
        else if (!data.Stage1)
        {
            stage1T.SetActive(false);
            stage1F.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            if (!bmap)
            {
                map.SetActive(true);
                bmap = true;
            }
            else if (bmap)
            {
                map.SetActive(false);
                bmap = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!bEscape)
            {
                bEscape = true;
                escape.SetActive(true);
                escapehud.SetActive(false);
            }
            else if (bEscape)
            {
                bEscape = false;
                escape.SetActive(false);
                escapehud.SetActive(true);
            }
        }

        //enable or disable enoki
        if (bEscape || bmap)
        {
            player.disabled = true;
            Time.timeScale = 0;
        }
        else if (!bEscape && !bmap)
        {
            player.disabled = false;
            Time.timeScale = 1;
        }
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        if (!music)
        {
            mTrue.SetActive(true);
            mFalse.SetActive(false);
            music = true;
        }
        else if (music)
        {
            mTrue.SetActive(false);
            mFalse.SetActive(true);
            music = false;
        }
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
        if (!sfx)
        {
            eTrue.SetActive(true);
            eFalse.SetActive(false);
            sfx = true;
        }
        else if (sfx)
        {
            eTrue.SetActive(false);
            eFalse.SetActive(true);
            sfx = false;
        }
    }

    public void MusicVol()
    {
        AudioManager.Instance.MusicVol(MusicSlider.value);
        mTrue.SetActive(false);
        mFalse.SetActive(true);
        music = false;
        AudioManager.Instance.togglem = false;
    }

    public void SFXVol()
    {
        AudioManager.Instance.SFXVol(SFXSlider.value);
        eTrue.SetActive(false);
        eFalse.SetActive(true);
        sfx = false;
        AudioManager.Instance.toggle = false;
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

    public void SaveExit()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}