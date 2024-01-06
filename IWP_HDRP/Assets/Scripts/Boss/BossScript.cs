using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class BossScript : MonoBehaviour
{
    public static BossScript instance;
    public UnityEvent Cutscene,Cutscene2;//invoke cutscene
    [SerializeField] GameObject boulder;//rand 3 local points and spawn 4 in each point using localpos
    public List<GameObject> boulderSpawn = new List<GameObject>();

    [Header("Boss Stats")]
    [SerializeField] bool phaseStart = false;
    [SerializeField] int phase = 0;
    [SerializeField] public int lifes = 0;
    [SerializeField] int boulderCount;
    [SerializeField] float timer,resetTimer = 60f;
    [SerializeField] float intervalTimer, resetIntervalTimer = 5f;

    [Header("Boss Run Stats")]
    public UnityEvent WinCutscene;
    public GameObject bossModel, entPt;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (PlayerData.instance.GetDifficulty() == 0)
            lifes = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BossScene"))
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
                    case 1://slam attack(falling boulder + boss slam)
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
                            Cutscene2.Invoke();
                            SceneManager.LoadScene("BossRunScene");
                            break;
                        }
                    default:
                        break;
                }
                if (lifes < 0)
                {
                    //gameover ui
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }

        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BossRunScene"))
        {
            bossModel.transform.position += (new Vector3(0, 0, 4) * Time.deltaTime);
        }
    }

    private IEnumerator SpawnBoulder()
    {
        for (int j = 0; j < boulderCount; j++)
        {
            for (int i = 0; i < boulderSpawn.Count; i++)
            {
                float randx = Random.Range(-5f, 5f);
                float randz = Random.Range(-5f, 5f);

                Vector3 spawnPosition = boulderSpawn[i].transform.position + new Vector3(randx, 1.5f, randz);
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

    public void WinGame()
    {
        Debug.Log("win");
        WinCutscene.Invoke();
    }

    public void StartPhase()
    {
        phaseStart = true;
    }
    public void PhaseBegin()
    {
        phaseStart = true;
        Cutscene.Invoke();
    }
}
