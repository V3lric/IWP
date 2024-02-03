using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class BossScript : MonoBehaviour
{
    public static BossScript instance;
    public UnityEvent Cutscene,Cutscene2;//invoke cutscene
    public GameObject vcam, bossIndicator;
    public Transform bossSlamPos;
    [SerializeField] GameObject boulder;//rand 3 local points and spawn 4 in each point using localpos
    public List<GameObject> boulderSpawn = new List<GameObject>();
    [SerializeField] Vector3 bossOGPos;
    [SerializeField]Animator animator;
    private bool doneSmashing;

    [Header("Boss Stats")]
    [SerializeField] bool phaseStart = false;
    [SerializeField] public int phase = 0;
    [SerializeField] public int lifes = 0;
    [SerializeField] int boulderCount;
    [SerializeField] float timer,resetTimer,slamTimer = 60f;
    [SerializeField] float intervalTimer, resetIntervalTimer = 5f;
    bool once = false;
    [Header("Boss Run Stats")]
    public UnityEvent WinCutscene;
    public GameObject bossModel, entPt;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        bossOGPos = bossModel.transform.position;
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
                                AudioManager.Instance.PlaySFX("FallingRocks");
                                intervalTimer = resetIntervalTimer;
                                animator.SetTrigger("SmashingGround");
                                StartCoroutine(SpawnBoulder());
                            }
                            break;
                        }
                    case 1://slam attack(falling boulder + boss slam)
                        {
                            if (!once)
                            {
                                DialogManager.instance.CustomText("Argghhh you're dead!","Slug");
                                once = true;
                            }

                            if (doneSmashing)
                            {
                                var step = 6f * Time.deltaTime; // calculate distance to move
                                bossModel.transform.position = Vector3.MoveTowards(bossModel.transform.position, bossOGPos, step);

                                if (bossModel.transform.position == bossOGPos)
                                {
                                    doneSmashing = false;
                                }
                            }

                            Timer();
                            if (intervalTimer < 0)
                            {
                                AudioManager.Instance.PlaySFX("FallingRocks");
                                intervalTimer = resetIntervalTimer;
                                //play slam anim
                                StartCoroutine(SpawnBoulder());
                            }

                            slamTimer -= 1f * Time.deltaTime;
                            if (slamTimer < 0)
                            {
                                animator.Play("BossSlam");
                                StartCoroutine(BossSlam());
                                slamTimer = 7f;
                            }
                            break;
                        }
                    case 2://running away
                        {
                            Cutscene2.Invoke();
                            break;
                        }
                    default:
                        break;
                }
                if (lifes < 0)
                {
                    //gameover ui
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    AudioManager.Instance.StopSound("FallingRocks");
                }
            }
        }

        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BossRunScene"))
        {
            animator.Play("Walking");
            bossModel.transform.position += (new Vector3(0, 0, 4) * Time.deltaTime);
            if (lifes < 0)
            {
                //gameover ui
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    public void StartPhase()
    {
        AudioManager.Instance.PlaySFX("FallingRocks");
        bossModel.SetActive(true);
        phaseStart = true;
        vcam.SetActive(true);
        DialogManager.instance.CustomText("Watch out for the falling boulders!","Truffle");
    }

    public void PhaseBegin()
    {
        AudioManager.Instance.StopSound("BossScene");
        DialogManager.instance.BossIntro();
        Cutscene.Invoke();
    }

    public void ChangeYPos(float y)
    {
        bossModel.transform.position = new Vector3(bossModel.transform.position.x, y, bossModel.transform.position.z) * Time.deltaTime;
    }

    public void BossRun()
    {
        SceneManager.LoadScene("BossRunScene");
    }
    public void WinGame()
    {
        PlayerData.instance.StageBoss = true;
        AudioManager.Instance.StopSound("BossRunScene");
        //cutscene
        WinCutscene.Invoke();
        StartCoroutine(WinGameCutScene());
    }

    IEnumerator WinGameCutScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("HubScene");
    }

    private IEnumerator BossSlam()
    {
        float randx = Random.Range(-8f, 8f);
        Vector3 spawnPosition = bossSlamPos.transform.position + new Vector3(randx, 0, 0);
        bossIndicator.transform.position = spawnPosition;
        bossIndicator.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        bossModel.transform.position = spawnPosition;
        bossIndicator.SetActive(false);

        // Waits for anim to play fin before shaking vcam
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length - 2.5f);

        VCamShake.instance.CameraShakeVCam(10f, 1f);
        animator.Play("Walking");
        doneSmashing = true;
    }

    private IEnumerator SpawnBoulder()
    {
        for (int j = 0; j < boulderCount; j++)
        {
            for (int i = 0; i < boulderSpawn.Count; i++)
            {
                float randx = Random.Range(-4.5f, 4.5f);
                float randz = Random.Range(-4.5f, 4.5f);

                Vector3 spawnPosition = boulderSpawn[i].transform.position + new Vector3(randx, 1.5f, randz);
                GameObject go = Instantiate(boulder, spawnPosition, Quaternion.identity);
                go.transform.parent = boulderSpawn[i].transform;
                VCamShake.instance.CameraShakeVCam(1f,2f);
                yield return new WaitForSeconds(0.3f);
            }
        }
    }

}
