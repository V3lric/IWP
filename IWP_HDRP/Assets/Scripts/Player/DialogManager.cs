using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject dialog;
    public TextMeshProUGUI DialogPerson, DialogText;
    [SerializeField] string[] chatText;
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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
