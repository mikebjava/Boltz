using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    private Text display;
    private PlayerStatsController psc;

    void Start()
    {
        psc = GameController.Instance().boltzInstance.GetComponent<PlayerStatsController>() as PlayerStatsController;
        if (psc == null)
        {
            Debug.LogWarning("ScoreDisplay was unable to retrieve an instance of Boltz PlayerStatsController. This may cause problems.");
        }
        else
        {
            psc.ScoreChanged += SyncScoreOnChange;
        }

        display = GetComponent<Text>();
        if (display == null)
        {
            Debug.LogWarning("Text display component for ScoreDisplay was not found. This may cause problems.");
        }
    }

    private void SyncScoreOnChange(object sender, ScoreChangedEventArgs e)
    {
        if (display != null)
        {
            display.text = "Score: " + e.CurrentScore;
        }
    }


}
