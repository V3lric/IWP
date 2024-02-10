using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChat : MonoBehaviour
{
    public string Player = "Player";
    public GameObject text;
    public bool hit = false;
    [SerializeField] ChatBubbleScript bubble;

    int randInt;
    [Header("NPC Chat")]
    [SerializeField] string textName;
    [SerializeField] string[] chat;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hit)
        {
            bubble.DotBubble();
            DialogManager.instance.CustomText(chat[randInt], textName);
        }
    }
    private void RandInt()
    {
        randInt = Random.Range(0, chat.Length);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Player))
        {
            text.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Player))
        {
            RandInt();
            hit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
        hit = false;
    }
}
