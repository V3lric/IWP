using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineShakeEffect : MonoBehaviour
{
    public static CineMachineShakeEffect Instance { get; private set; }
    private CinemachineFreeLook virtualCamera;
    private CinemachineBasicMultiChannelPerlin[] perlinComponents;
    public float shakeTimer;

    void Start()
    {
        Instance = this;
        virtualCamera = GetComponent<CinemachineFreeLook>();

        // Assuming you have 3 rigs, adjust the size accordingly
        perlinComponents = new CinemachineBasicMultiChannelPerlin[3];

        for (int i = 0; i < perlinComponents.Length; i++)
        {
            perlinComponents[i] = virtualCamera.GetRig(i).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime * 1f;
            if (shakeTimer <= 0)
            {
                // Disable cam shake for each rig
                foreach (var perlinComponent in perlinComponents)
                {
                    perlinComponent.m_AmplitudeGain = 0f;
                }
            }
        }
    }

    public void CameraShake(float intensity, float time)
    {
        // Apply cam shake to each rig
        foreach (var perlinComponent in perlinComponents)
        {
            perlinComponent.m_AmplitudeGain = intensity;
        }

        shakeTimer = time;
    }

    public void CameraShakeReset()
    {
        // Apply cam shake to each rig
        foreach (var perlinComponent in perlinComponents)
        {
            perlinComponent.m_AmplitudeGain = 0f;
        }
    }
}

