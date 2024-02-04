using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    public GameObject dialog;
    public TextMeshProUGUI DialogPerson, DialogText;
    [SerializeField] string[] chatText,scene1Win,bossIntro,bossRun;
    public bool cutscene1, cutscene2 = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void Dialog()
    {
            StartCoroutine(DialogSpeech());
    }
    public void BossIntro()
    {
        StartCoroutine(BossIntroSpeech());
    }
    public void BossRun()
    {
        StartCoroutine(BossIntroSpeech());
    }
    public void OffDialog(){
        dialog.SetActive(false);
        DialogPerson.text = "";
        DialogText.text = "";
    }
    public void CustomText(string text, string person)
    {
        StartCoroutine(DialogSpeechText(text, person));
    }
    public void Scene1WinSpeech()
    {
        StartCoroutine(WinSpeech());
    }
    IEnumerator WinSpeech()
    {
        int speech = 0;
        yield return new WaitForSeconds(0.5f);
        DialogPerson.text = "Truffle";
        DialogText.text = scene1Win[speech];
        yield return new WaitForSeconds(5f);
        DialogPerson.text = "Enoki";
        speech++;
        DialogText.text = scene1Win[speech];
        yield return new WaitForSeconds(2f);
        DialogPerson.text = "Truffle";
        speech++;
        DialogText.text = scene1Win[speech];
    }
    IEnumerator BossIntroSpeech()
    {
        if (BossScript.instance.phase == 0)
        {
            int speech = 0;
            yield return new WaitForSeconds(4f);
            DialogPerson.text = "Slug";
            DialogText.text = bossIntro[speech];
            dialog.SetActive(true);
            yield return new WaitForSeconds(6f);
            DialogPerson.text = "Slug";
            speech++;
            DialogText.text = bossIntro[speech];
            yield return new WaitForSeconds(4f);
            DialogPerson.text = "Slug";
            speech++;
            DialogText.text = bossIntro[speech];
            yield return new WaitForSeconds(4f);
            DialogPerson.text = "Enoki";
            speech++;
            DialogText.text = bossIntro[speech];
            yield return new WaitForSeconds(4.5f);
            DialogPerson.text = "Slug";
            speech++;
            DialogText.text = bossIntro[speech];
            yield return new WaitForSeconds(4f);
            dialog.SetActive(false);
            DialogText.text = "";
        }
        else if (BossScript.instance.phase == 2)
        {
            int speech = 0;
            DialogPerson.text = "Enoki";
            DialogText.text = bossRun[speech];
            yield return new WaitForSeconds(4f);
            DialogPerson.text = "Slug";
            speech++;
            DialogText.text = bossRun[speech];
            yield return new WaitForSeconds(3.5f);
            DialogPerson.text = "Truffle";
            speech++;
            DialogText.text = bossRun[speech];
            yield return new WaitForSeconds(4f);
            dialog.SetActive(false);
            DialogText.text = "";
        }
    }
    IEnumerator DialogSpeechText(string text,string person)
    {
        DialogText.text = text;
        DialogPerson.text = person;
        dialog.SetActive(true);
        yield return new WaitForSeconds(4f);
        dialog.SetActive(false);
        DialogText.text = "";
    }

    IEnumerator DialogSpeech()
    {
        DialogText.text = chatText[GameManager.Instance.uiBubbleCP];
        dialog.SetActive(true);
        yield return new WaitForSeconds(4f);
        dialog.SetActive(false);
        DialogText.text = "";
    }
}
