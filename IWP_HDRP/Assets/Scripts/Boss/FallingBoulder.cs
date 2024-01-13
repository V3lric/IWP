using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBoulder : MonoBehaviour
{
    public GameObject boulder;

    // Update is called once per frame
    void Update()
    {
        if (PlayerData.instance.GetDifficulty() == 2)
            gameObject.GetComponent<Rigidbody>().velocity += new Vector3(0,-10f,0) * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("BoulderEndPt"))
        {
            Destroy(boulder);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Hit");
            BossScript.instance.lifes--;
            Destroy(boulder);
        }
    }
}
