using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeDisplay : MonoBehaviour
{


    private Text display;
    private PlayerVitalsController pvc;

    void Start()
    {
        display = GetComponent<Text>();
        if (display == null)
        {
            Debug.LogWarning("Text display component for LifeDisplay was not found. This may cause problems.");
        }

        pvc = GameController.Instance().boltzInstance.GetComponent<PlayerVitalsController>() as PlayerVitalsController;
        if (pvc == null)
        {
            Debug.LogWarning("LifeDisplay was unable to retrieve an instance of Boltz PlayerVitalsController. This may cause problems.");
        }
        else
        {
            pvc.Damaged += SyncLife;
            display.text = "Life: " + pvc.CurrentLife;
        }


    }

    private void SyncLife(object sender, DamagedEventArgs e)
    {
        if (display != null)
        {
            display.text = "Life: " + e.CurrentLife;
        }
    }


}
