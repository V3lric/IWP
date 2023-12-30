using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossScript : MonoBehaviour
{
    public UnityEvent Cutscene,Cutscene2;//invoke cutscene
    [SerializeField] public int phase = 0;
    public bool phaseStart = false;
    [SerializeField] GameObject boulder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (phaseStart)
        {
            Cutscene.Invoke();
            switch (phase)//diff phases of boss
            {
                case 0://falling boulder
                    {

                        break;
                    }
                case 1://slam attack
                    {

                        break;
                    }
                case 2://running away
                    {

                        break;
                    }
                default:
                    break;
            }
        }
    }
}
