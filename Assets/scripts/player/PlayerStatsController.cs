using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class PlayerStatsController : MonoBehaviour
{

    #region Editor Variables
    public int CurrentScore = 0;
    #endregion


    #region Events
    public event EventHandler<ScoreChangedEventArgs> ScoreChanged;
    public virtual void OnScoreChangedEvent(object obj, ScoreChangedEventArgs args)
    {
        if (ScoreChanged != null)
        {
            ScoreChanged(obj, args);
        }
    }
    #endregion

    public void ModifyScore(int value)
    {
        CurrentScore += value;
        ScoreChangedEventArgs args = new ScoreChangedEventArgs();
        args.PreviousScore = CurrentScore - value;
        args.CurrentScore = CurrentScore;
        args.ValueChanged = value;
        OnScoreChangedEvent(this, args);
    }
}

