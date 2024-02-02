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
    public AudioMixer music;
    public static AudioManager Instance;
    public bool toggle, togglem = false;
    Scene activeScene,prevScene;

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
            Destroy(this.gameObject);
        }


    }
    private void Start()
    {
        if (gameObject != null)
            SceneManager.sceneLoaded += OnSceneWasLoaded;
    }
    void OnSceneWasLoaded(Scene scene, LoadSceneMode loadMode)
    {
        //StopBGM();
        PlayBGM();
    }

    private void PlayBGM()
    {
        if (activeScene != SceneManager.GetActiveScene())
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
                PlaySound("MainMenu");
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("HubScene"))
                PlaySound("HubScene");
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Scene1"))
                PlaySound("Scene1");
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BossScene"))
                PlaySound("BossScene");
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BossRunScene"))
                PlaySound("BossRunScene");

            prevScene = activeScene;
        }
    }

    private void StopBGM()
    {
        if (prevScene == SceneManager.GetSceneByName("MainMenu"))
            StopSound("MainMenu");
        else if (prevScene == SceneManager.GetSceneByName("PreTutCutscene"))
            StopSound("MainMenu");
        else if (prevScene == SceneManager.GetSceneByName("HubScene"))
            StopSound("MainMenu");
        else if (prevScene == SceneManager.GetSceneByName("Scene1"))
            StopSound("HubScene");
        else if (prevScene == SceneManager.GetSceneByName("BossScene"))
            StopSound("Scene1");
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
            if (!sfxSource.isPlaying)
            {
                sfxSource.PlayOneShot(sound.clip);
            }
        }
    }
    public bool audioDSFX = false;
    public void PlayDSFX(string name)
    {
        Sound sound = Array.Find(sfxSound, x => x.name == name);

        if (sound == null)
            Debug.LogWarning("Sound not found");
        else
        {
            if (!audioDSFX)
            {
                sfxSource.PlayOneShot(sound.clip);
                audioDSFX = true;
            }
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
            music.SetFloat("SFX", Mathf.Log10(0.0001f) * 20);
            toggle = true;
        }
        else if (toggle)
        {
            music.SetFloat("SFX", Mathf.Log10(sfxSource.volume) * 20);
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
        music.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}
