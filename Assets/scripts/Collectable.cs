using UnityEngine;
using System.Collections;
using System;

public class Collectable : MonoBehaviour
{

    #region Editor Variables
    public int Value = 100;
    public bool DestroyOnCollect = true;
    #endregion

    #region Events
    public event EventHandler<CollectableCollectedEventArgs> Collected;
    public virtual void OnCollected(object obj, CollectableCollectedEventArgs args)
    {
        if (Collected != null)
        {
            Collected(obj, args);
        }
    }
    #endregion

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            PlayerStatsController psc = GameController.Instance().boltzInstance.GetComponent<PlayerStatsController>() as PlayerStatsController;
            psc.ModifyScore(Value);
            if (DestroyOnCollect)
                Destroy(gameObject);
        }
    }
}
