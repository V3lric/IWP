using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubbleScript : MonoBehaviour
{
    [SerializeField] Transform vCamTransform;
    public TextMeshProUGUI bubbleText;
    public GameObject BubbleGO;
    public bool triggered;
    [SerializeField] string[] chatText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(vCamTransform);
        if (triggered)
        {
            StartCoroutine(SpeechBubble());
            StartCoroutine(SpeechBubbleDot());
            triggered = false;
        }
    }

    public void DotBubble()
    {
        StartCoroutine(SpeechBubble());
        StartCoroutine(SpeechBubbleDot());
    }
    IEnumerator SpeechBubble()
    {
        //bubbleText.text = chatText[manager.uiBubbleCP];
        BubbleGO.SetActive(true);
        yield return new WaitForSeconds(4f);
        BubbleGO.SetActive(false);
        bubbleText.text = "";
        triggered = false;
    }

    IEnumerator SpeechBubbleDot()
    {
        for (int i = 0; i < 4f; i++)
        {
            bubbleText.text += ".";
            if (i >= 3)
                i = 0;
            if (bubbleText.text.Length > 3)
            {
                bubbleText.text = "";
            }
            yield return new WaitForSeconds(0.4f);
        }
    }

    public IEnumerator SpeechBubbleText(string text)
    {
        //bubbleText.text = text;
        BubbleGO.SetActive(true);
        yield return new WaitForSeconds(4f);
        BubbleGO.SetActive(false);
    }
}
