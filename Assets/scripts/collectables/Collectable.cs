using UnityEngine;
using System.Collections;
using System;

public class Collectable : MonoBehaviour
{

    #region Editor Variables
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
            if (DestroyOnCollect)
                Destroy(gameObject);
            CollectableCollectedEventArgs args = new CollectableCollectedEventArgs();
            args.Collector = coll.gameObject;
            OnCollected(this, args);
        }
    }
}
