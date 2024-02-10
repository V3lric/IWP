using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneDirector : MonoBehaviour
{
    public PlayableDirector director;

    public void Play()
    {
        director.Play();
    }

    public void Trigger()
    {
        SceneManager.LoadScene("HubScene");
    }

    public void Skip()
    {
        director.time = director.playableAsset.duration;
    }
}
