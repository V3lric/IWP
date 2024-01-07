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

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void BossIntro()
    {
        StartCoroutine(BossIntroSpeech());
    }
    IEnumerator BossIntroSpeech()
    {
        int speech = 0;
        yield return new WaitForSeconds(2f);
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
        yield return new WaitForSeconds(4f);
        DialogPerson.text = "Slug";
        speech++;
        DialogText.text = bossIntro[speech];
        yield return new WaitForSeconds(4f);
        dialog.SetActive(false);
        DialogText.text = "";
    }
    IEnumerator DialogSpeech()
    {
        //DialogText.text = chatText[manager.uiBubbleCP];
        dialog.SetActive(true);
        yield return new WaitForSeconds(4f);
        dialog.SetActive(false);
        DialogText.text = "";
    }
}
