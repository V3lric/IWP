using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public string Player = "Player";
    public GameObject text;
    public bool isSwitched,hit = false;
    public Animator animator;
    public float timer = 0f;
    public float reset = 1.2f;
    public bool once = true;
    public int switchID;
    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime * 1f;

        if (Input.GetKeyDown(KeyCode.E) && hit)
        {
            once = false;
            if (!isSwitched && timer <= 0)
            {
                isSwitched = true;
                animator.SetTrigger("Up");
                timer = reset;
            }
            else if (isSwitched && timer <= 0)
            {
                isSwitched = false;
                animator.SetTrigger("Down");
                timer = reset;
            }

            if (SwitchManager.Instance.switchOrder[switchID] == isSwitched)
                AudioManager.Instance.PlaySFX("SwitchCorrect");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Player))
        {
            text.SetActive(true);
            hit = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Player))
            hit = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Player))
        {
            text.SetActive(false);
            hit = false;
        }
    }
}
