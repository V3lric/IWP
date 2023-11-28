using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public Sound[] musicSound, sfxSound;
    public AudioSource musicSource, sfxSource;
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
            Destroy(gameObject);

        if (SceneManager.GetActiveScene().name == "HubScene")
        {
            PlaySound("MainMenu");
            StopSound("Scene1");
        }
        if (SceneManager.GetActiveScene().name == "Scene1")
        {
            PlaySound("Scene1");
            StopSound("MainMenu");
        }
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
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVol(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVol(float volume)
    {
        sfxSource.volume = volume;
    }
}
