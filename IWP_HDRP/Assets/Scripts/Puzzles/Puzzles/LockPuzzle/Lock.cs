using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public string Player = "Player";
    public GameObject text, wheel, camera;
    public bool hit = false;
    public float rotationSpeed = 90.0f; // Adjust the speed as needed
    private bool isRotating = false;
    public int currentImg = 0;

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
                currentImg++;
                if (currentImg > 4)
                    currentImg = 0;
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
        hit = true;
        camera.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
        hit = false;
        camera.SetActive(false);
    }
}
