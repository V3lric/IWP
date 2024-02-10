using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoulder : MonoBehaviour
{
    public GameObject Boulder,Shake,rLight,gLight;
    public Transform[] array = new Transform[6];
    float timer = 2f;
    int random;
    bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime * 1f;
        if (timer < 0 && !done)
        {
            timer = 2f;
            random = Random.Range(0, array.Length);
            Instantiate(Boulder, array[random].transform.position, Quaternion.identity);
            Boulder.GetComponent<Rigidbody>().AddForce(new Vector3(10, 0, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            done = true;
            CineMachineShakeEffect.Instance.CameraShakeReset();
            Shake.SetActive(false);
            gLight.SetActive(true);
            rLight.SetActive(false);
        }
    }
}
