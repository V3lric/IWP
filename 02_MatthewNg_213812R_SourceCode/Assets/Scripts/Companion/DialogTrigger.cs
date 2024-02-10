using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] string text, textName;
    [SerializeField] ChatBubbleScript bubble;
    bool once = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && !once)
        {
            DialogManager.instance.CustomText(text, textName);
            bubble.DotBubble();
            once = true;
        }
    }
}
