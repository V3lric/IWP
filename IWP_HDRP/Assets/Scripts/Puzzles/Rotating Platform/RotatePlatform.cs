using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public GameObject text, wheel, vCamera;
    public float rotationSpeed = 90.0f; // Adjust the speed as needed
    private bool isRotating = false;
    [SerializeField] bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hit)
        {
            if (!isRotating)
            {
                StartCoroutine(RotateWheel());
            }
        }
    }

    private IEnumerator RotateWheel()
    {
        isRotating = true;
        Quaternion startRotation = wheel.transform.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0, 90, 0);
        float elapsedTime = 0;
        float duration = Mathf.Abs(90.0f / rotationSpeed);

        while (elapsedTime < duration)
        {
            wheel.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        wheel.transform.rotation = targetRotation;
        isRotating = false;
    }
    private void OnTriggerStay(Collider other)
    {
        hit = true;
        vCamera.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
        hit = false;
        vCamera.SetActive(false);
    }
}
