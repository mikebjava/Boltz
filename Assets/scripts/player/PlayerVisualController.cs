
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityStandardAssets.ImageEffects;


public class PlayerVisualController : MonoBehaviour
{

    #region Editor Variables
    public float VCAMaximumIntensity = 15.0f;
    public float VCAMinimumIntesity = 0.1f;
    public float VCALerpSpeed = 0.1f;
    public float VCAVignettingMinimum = 3.0f;
    public float VCAVignettingMaximum = 12.0f;
    public float VCABlurMinimum = 0.0f;
    public float VCABlurMaximum = 10.0f;
    #endregion

    private PlayerVitalsController vitals;
    private VignetteAndChromaticAberration vca;
    private ScreenOverlay overlay;

    void Start()
    {
        vitals = gameObject.GetComponent<PlayerVitalsController>() as PlayerVitalsController;
        vitals.Damaged += OnPlayerDamaged;
        vitals.Death += OnPlayerDeath;

        if (Camera.main != null)
        {
            vca = Camera.main.GetComponent<VignetteAndChromaticAberration>() as VignetteAndChromaticAberration;
            if (vca == null)
            {
                Debug.LogWarning("PlayerVisualController was unable to find VCA image effect on the main camera. This may cause problems.");
            }

            overlay = Camera.main.GetComponent<ScreenOverlay>() as ScreenOverlay;
            if (overlay == null)
            {
                Debug.LogWarning("PlayerVisualController was unable to find ScreenOverlay image effect on the main camera. This may cause problems.");
            }
        }
        else
        {
            Debug.LogWarning("PlayerVisualController was unable to find the main camera. This may cause problems.");
        }
    }

    private void OnPlayerDeath(object sender, DeathEventArgs e)
    {
        
    }

    void Update()
    {
        float vig = Mathf.Clamp((vitals.MaximumLife - vitals.CurrentLife) * (VCAVignettingMaximum / vitals.MaximumLife), VCAVignettingMinimum, VCAVignettingMaximum);
        float blur = Mathf.Clamp((vitals.MaximumLife - vitals.CurrentLife) * (VCABlurMaximum / vitals.MaximumLife), VCABlurMinimum, VCABlurMaximum);

        vca.chromaticAberration = Mathf.Lerp(vca.chromaticAberration, VCAMinimumIntesity, VCALerpSpeed * Time.deltaTime);
        vca.intensity = Mathf.Lerp(vca.intensity, vig, VCALerpSpeed * Time.deltaTime);
        vca.blur = Mathf.Lerp(vca.blur, blur, VCALerpSpeed * Time.deltaTime);
    }

    private void OnPlayerDamaged(object sender, DamagedEventArgs e)
    {
        vca.chromaticAberration = VCAMaximumIntensity;
        overlay.intensity = 1.0f;
    }

}

