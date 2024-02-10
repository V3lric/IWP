using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSettings : MonoBehaviour
{
    public GameObject mTrue, mFalse;//music icon
    public GameObject eTrue, eFalse;//escape icon
    [SerializeField] bool music, sfx = false;
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
}
