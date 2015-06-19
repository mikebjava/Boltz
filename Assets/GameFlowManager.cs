using UnityEngine;
using System.Collections;

public class GameFlowManager : MonoBehaviour
{

    #region Editor Variables
    public string NextLevel;
    public int RequiredCollectableCount = 3;
    #endregion

    private PlayerStatsController psc;

    void Start()
    {
        psc = GameController.Instance().Boltz.GetComponent<PlayerStatsController>() as PlayerStatsController;
        if (psc == null)
        {
            Debug.LogWarning("GameFlowManager was unable to locate the PlayerStatsController. This will cause problems.");
        }
        else
        {
            psc.ScoreChanged += OnScoreChanged;
        }
    }

    private void OnScoreChanged(object sender, ScoreChangedEventArgs e)
    {
        if (psc.CollectableCount >= RequiredCollectableCount)
        {
            TriggerWin();
        }
    }

    private void TriggerWin()
    {
        Application.LoadLevel(NextLevel);
    }

}
