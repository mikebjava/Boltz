using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.ImageEffects;

public class InGameMenuToggler : MonoBehaviour
{

    #region Editor Variables
    public Canvas InGameMenu;
    #endregion

    private PauseController pauseCtrl;
    private BlurOptimized blur;

    void Start()
    {
        if (Camera.main != null)
        {
            blur = Camera.main.GetComponent<BlurOptimized>() as BlurOptimized;
            if (blur == null)
            {
                Debug.LogWarning("No blur script found on camera. This may cause problems.");
            }
        }
        else
        {
            Debug.LogError("No camera found! InGameMenuToggler WILL NOT WORK without a camera!");
        }

        pauseCtrl = GetComponent<PauseController>() as PauseController;
        if (pauseCtrl == null)
        {
            Debug.LogError("InGameMenuToggler couldn't find a PauseController! This WILL CAUSE PROBLEMS!");
        }
        else
        {
            pauseCtrl.Paused += OnPaused;
            pauseCtrl.Unpaused += OnUnpaused;
        }

        if (InGameMenu == null)
        {
            Debug.LogError("InGameMenuToggler couldn't find a InGameMenu! This WILL CAUSE PROBLEMS!");
        }

        if (InGameMenu != null && pauseCtrl != null)
        {
            InGameMenu.enabled = pauseCtrl.IsPaused;
        }
    }

    private void OnUnpaused(object sender, EventArgs e)
    {
        InGameMenu.enabled = false;
        blur.enabled = false;
    }

    private void OnPaused(object sender, EventArgs e)
    {
        InGameMenu.enabled = true;
        blur.enabled = true;
    }

}
