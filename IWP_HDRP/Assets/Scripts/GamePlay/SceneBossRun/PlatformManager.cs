using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab,prefabContainer,platform;
    // Start is called before the first frame update
    void Start()
    {
        platform = Instantiate(platformPrefab, prefabContainer.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(platform);
            platform = Instantiate(platformPrefab, prefabContainer.transform);
        }
    }
}
