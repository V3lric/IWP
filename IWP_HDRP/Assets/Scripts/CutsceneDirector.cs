using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneDirector : MonoBehaviour
{
    public PlayableDirector director;

    public void Play()
    {
        director.Play();
    }
}