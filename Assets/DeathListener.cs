using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class DeathListener : MonoBehaviour
{

    #region Editor Variables
    public Canvas DeathScreenUI;
    #endregion

    private PlayerVitalsController pvc;
    private BlurOptimized blur;
    private PauseController pc;

    void Start()
    {
        pc = GetComponent<PauseController>();
        if (pc == null)
        {
            Debug.LogWarning("DeathListener was unable to find the PauseController. This may cause problems.");
        }

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

        pvc = GameController.Instance().Boltz.GetComponent<PlayerVitalsController>();
        if (pvc == null)
        {
            Debug.LogWarning("DeathListener was unable to locate the PlayerVitalsController. This will cause problems.");
        }
        else
        {
            pvc.Death += OnPlayerDeath;
        }

        DeathScreenUI.enabled = false;
    }

    private void OnPlayerDeath(object sender, DeathEventArgs e)
    {
        blur.enabled = true;
        DeathScreenUI.enabled = true;
        pc.PausingEnabled = false;
    }

}
