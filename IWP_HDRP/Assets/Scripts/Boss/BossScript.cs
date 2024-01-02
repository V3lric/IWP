using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class BossScript : MonoBehaviour
{
    public static BossScript instance;
    public UnityEvent Cutscene,Cutscene2;//invoke cutscene
    public bool phaseStart = false;
    [SerializeField] GameObject boulder;//rand 3 local points and spawn 4 in each point using localpos
    public List<GameObject> boulderSpawn = new List<GameObject>();
    [SerializeField] int phase = 0;

    [Header("Boss Stats")]
    [SerializeField] public int lifes = 0;
    [SerializeField] int boulderCount;
    [SerializeField] float timer,resetTimer = 60f;
    [SerializeField] float intervalTimer, resetIntervalTimer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (phaseStart)
        {
            switch (phase)//diff phases of boss
            {
                case 0://falling boulder (1 min, 10 boulder with 5s intervals)
                    {
                        Timer();
                        if (intervalTimer < 0)
                        {
                            intervalTimer = resetIntervalTimer;
                            //play slam anim
                            StartCoroutine(SpawnBoulder());
                        }
                        break;
                    }
                case 1://slam attack
                    {
                        Timer();
                        if (intervalTimer < 0)
                        {
                            intervalTimer = resetIntervalTimer;
                            //play slam anim
                            StartCoroutine(SpawnBoulder());
                        }
                        break;
                    }
                case 2://running away
                    {
                        Timer();
                        break;
                    }
                default:
                    break;
            }
            if (lifes < 0)
            {
                //gameover
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private IEnumerator SpawnBoulder()
    {
        for (int j = 0; j < boulderCount; j++)
        {
            for (int i = 0; i < boulderSpawn.Count; i++)
            {
                float randx = Random.Range(-6f, 6f);
                float randz = Random.Range(-6f, 6f);

                Vector3 spawnPosition = boulderSpawn[i].transform.position + new Vector3(randx, 1.7f, randz);
                GameObject go = Instantiate(boulder, spawnPosition, Quaternion.identity);
                go.transform.parent = boulderSpawn[i].transform;
                VCamShake.instance.CameraShakeVCam(1f,2f);
                yield return new WaitForSeconds(0.3f);
            }
        }
    }

    private void Timer()
    {
        timer -= 1f * Time.deltaTime;
        intervalTimer -= 1f * Time.deltaTime;

        if (timer < 0)
        {
            timer = resetTimer;
            phase++;
        }
    }
    public void PhaseBegin()
    {
        Cutscene.Invoke();
        phaseStart = true;
    }
}
