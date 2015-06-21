using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class CameraController : MonoBehaviour
{

    #region Editor Variables
    public float MinimumBloomIntensity = 0f;
    public float BloomLerpSpeed = 0.1f;
    #endregion

    private BloomOptimized bloom;

    void Awake()
    {
        bloom = GetComponent<BloomOptimized>() as BloomOptimized;
        if (bloom != null)
        {
            bloom.intensity = 16.0f;
        }
    }

    void Update()
    {
        if (bloom != null)
            bloom.intensity = Mathf.Lerp((float)bloom.intensity, MinimumBloomIntensity, BloomLerpSpeed);
    }
}
