using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCamShake : MonoBehaviour
{
    public static VCamShake instance;
    private CinemachineVirtualCamera virtualCamera;
    public float shakeTimer;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime * 1f;
            if (shakeTimer <= 0)
            {
                CinemachineBasicMultiChannelPerlin cinemachine = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachine.m_AmplitudeGain = 0f;
            }
        }
    }

    public void CameraShakeVCam(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachine = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachine.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
}
