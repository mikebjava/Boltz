using UnityEngine;
using System.Collections;

public class TimePowerUp : Collectable
{

    #region Editor Variables
    public int Value = 100;
    #endregion

    void Start()
    {
        Collected += AddTimeOnCollect;
    }

    private void AddTimeOnCollect(object sender, CollectableCollectedEventArgs e)
    {
        if (GameController.Instance().TimerDisplay != null)
        {
            GameController.Instance().TimerDisplay.Add(Value);
        }
    }

}
