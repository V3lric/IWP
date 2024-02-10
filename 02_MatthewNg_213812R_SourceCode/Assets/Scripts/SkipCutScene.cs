using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
public class SkipCutScene : MonoBehaviour
{
    private PlayableDirector _currentDirector;
    private bool _sceneSkipped = true;
    private float _timeToSkipTo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_sceneSkipped)
        {
            _currentDirector.time = _timeToSkipTo;
            _sceneSkipped = true;
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BossScene"))
                DialogManager.instance.cutscene1 = true;
        }
    }
    public void GetDirector(PlayableDirector director)
    {
        _sceneSkipped = false;
        _currentDirector = director;
    }
    public void GetSkipTime(float skipTime)
    {
        _timeToSkipTo = skipTime;
    }
}
