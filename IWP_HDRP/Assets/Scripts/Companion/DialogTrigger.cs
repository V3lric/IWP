using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] string text, name;
    [SerializeField] ChatBubbleScript bubble;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            DialogManager.instance.CustomText(text, name);
            bubble.DotBubble();
        }
    }
}
