using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject map,maphud;
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
                maphud.SetActive(false);
                bmap = true;
            }
            else if (bmap)
            {
                map.SetActive(false);
                maphud.SetActive(true);
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

        //disable enoki
        if (bEscape || bmap)
        {
            PlayerController.Instance.disabled = true;
            Time.timeScale = 0;
        }
        //enable enoki
        else if (!bEscape && !bmap)
        {
            PlayerController.Instance.disabled = false;
            Time.timeScale = 1;
        }
        if (SFXSlider.value == 0.0001f)
        {
            sfx = true;
            eTrue.SetActive(true);
            eFalse.SetActive(false);
        }
        if (MusicSlider.value == 0.0001f)
        {
            music = true;
            mTrue.SetActive(true);
            mFalse.SetActive(false);
        }
    }

    public void Portal()
    {
        map.SetActive(true);
        maphud.SetActive(false);
        bmap = true;
    }
    public void Quit()
    {
        Application.Quit();
        data.SaveToJSON();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        data.SaveToJSON();
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        if (!music)
        {
            PlayerData.instance.musicValue = MusicSlider.value;
            mTrue.SetActive(true);
            mFalse.SetActive(false);
            music = true;
            MusicSlider.value = 0.0001f;
        }
        else if (music)
        {
            mTrue.SetActive(false);
            mFalse.SetActive(true);
            music = false;
            MusicSlider.value = PlayerData.instance.musicValue;
        }
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
        if (!sfx)
        {
            PlayerData.instance.sfxValue = SFXSlider.value;
            eTrue.SetActive(true);
            eFalse.SetActive(false);
            sfx = true;
            SFXSlider.value = 0.0001f;
        }
        else if (sfx)
        {
            eTrue.SetActive(false);
            eFalse.SetActive(true);
            sfx = false;
            SFXSlider.value = PlayerData.instance.sfxValue;
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
        PlayerData.instance.musicValue = Volumn;
    }

    public void SetSFX(float Volumn)
    {
        SFXSlider.value = Volumn;
        AudioManager.Instance.SFXVol(SFXSlider.value);
        PlayerData.instance.sfxValue = Volumn;
    }
}