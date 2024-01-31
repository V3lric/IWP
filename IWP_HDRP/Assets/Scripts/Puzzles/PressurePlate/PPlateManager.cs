using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPlateManager : MonoBehaviour
{
    public static PPlateManager instance;
    public bool plateActivated;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        if (plateActivated)
            animator.SetTrigger("Trigger");
    }
}
