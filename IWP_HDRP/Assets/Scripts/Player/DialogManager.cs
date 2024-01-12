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
    GameManager manager;
    bool once = false;
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
    public void CustomText(string text)
    {
        StartCoroutine(DialogSpeechText(text));
    }
    IEnumerator BossIntroSpeech()
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
    IEnumerator DialogSpeechText(string text)
    {
        DialogText.text = text;
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
