using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubbleScript : MonoBehaviour
{
    public Transform target;
    public TextMeshProUGUI bubbleText;
    public GameObject BubbleGO;
    public bool triggered;
    [SerializeField] string[] chatText;
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Game").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        if (triggered)
            StartCoroutine(SpeechBubble());
    }

    IEnumerator SpeechBubble()
    {
        bubbleText.text = chatText[manager.uiBubbleCP];
        BubbleGO.SetActive(true);
        yield return new WaitForSeconds(4f);
        BubbleGO.SetActive(false);
        triggered = false;
    }
}
