using UnityEngine;
using Cinemachine;

public class ShotCam : MonoBehaviour
{
    private CinemachineVirtualCamera shotCam;
    private CinemachineBasicMultiChannelPerlin noise;

    [SerializeField] private float shakeIntensity = 2f;

    private void Awake() {
        shotCam = GetComponent<CinemachineVirtualCamera>();
        noise = shotCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void SetShot(Shot shot)
    {
        shotCam.Follow = shot.gameObject.transform;
    }

    public void Shake()
    {
        noise.m_AmplitudeGain = shakeIntensity;
        Invoke(nameof(StopShake), 0.65f);
    }

    public void StopShake()
    {
        noise.m_AmplitudeGain = 0f;
    }

}
