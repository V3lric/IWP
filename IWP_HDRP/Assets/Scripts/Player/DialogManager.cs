using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    public GameObject dialog;
    public TextMeshProUGUI DialogPerson, DialogText;
    [SerializeField] string[] chatText,bossIntro;
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
    public void OffDialog(){
        dialog.SetActive(false);
    }
    public void CustomText(string text, string person)
    {
        StartCoroutine(DialogSpeechText(text, person));
    }

    IEnumerator BossIntroSpeech()
    {
        if (cutscene1)
        {
            DialogPerson.text = "";
            DialogText.text = "";
            yield break;
        }
        else
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
