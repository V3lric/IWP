using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSettings : MonoBehaviour
{
    public GameObject mTrue, mFalse;//music icon
    public GameObject eTrue, eFalse;//escape icon
    [SerializeField] bool music, sfx = false;
    public Slider MusicSlider, SFXSlider;

    private void Start()
    {
        MusicSlider.value = AudioManager.Instance.musicSource.volume;
        SFXSlider.value= AudioManager.Instance.sfxSource.volume;
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
