using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ScoreCollectable : Collectable
{

    #region Editor Variables
    public int Value = 100;
    #endregion

    void Start()
    {
        Collected += AddScoreOnCollect;
    }

    private void AddScoreOnCollect(object sender, CollectableCollectedEventArgs e)
    {
        PlayerStatsController psc = e.Collector.GetComponent<PlayerStatsController>() as PlayerStatsController;
        psc.ModifyScore(Value);
    }

}

