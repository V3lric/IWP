using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public Sound[] musicSound, sfxSound;
    public AudioSource musicSource, sfxSource;
    public AudioMixer music, sfx;
    public static AudioManager Instance;
    public bool toggle, togglem = false;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Debug.Log("More than 1 instance detected");
            Destroy(gameObject);
        }

        PlaySound("MainMenu");
    }
    public void PlaySound(string name)
    {
        Sound sound = Array.Find(musicSound, x => x.name == name);

        if (sound == null)
            Debug.LogWarning("Sound not found");
        else
        {
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

    public void StopSound(string name)
    {
        Sound sound = Array.Find(musicSound, x => x.name == name);

        if (sound == null)
            Debug.LogWarning("Sound not found");
        else
        {
            musicSource.clip = sound.clip;
            musicSource.Stop();
        }
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSound, x => x.name == name);

        if (sound == null)
            Debug.LogWarning("Sound not found");
        else
        {
            sfxSource.PlayOneShot(sound.clip);
        }
    }

    public void ToggleMusic()
    {
        //musicSource.mute = !musicSource.mute;
        if (!togglem)
        {
            music.SetFloat("Music", Mathf.Log10(0.0001f) * 20);
            togglem = true;
        }
        else if (togglem)
        {
            music.SetFloat("Music", Mathf.Log10(sfxSource.volume) * 20);
            togglem = false;
        }
    }

    public void ToggleSFX()
    {
        //sfxSource.mute = !sfxSource.mute;
        if (!toggle)
        {
            sfx.SetFloat("SFX", Mathf.Log10(0.0001f) * 20);
            toggle = true;
        }
        else if (toggle)
        {
            sfx.SetFloat("SFX", Mathf.Log10(sfxSource.volume) * 20);
            toggle = false;
        }
    }

    public void MusicVol(float volume)
    {
        musicSource.volume = volume;
        music.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public void SFXVol(float volume)
    {
        sfxSource.volume = volume;
        sfx.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}
