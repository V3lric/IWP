using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubbleScript : MonoBehaviour
{
    public Transform target;
    public TextMeshProUGUI bubbleText;
    public string[] chatText;
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
        bubbleText.text = chatText[manager.uiBubbleCP];
    }
}
