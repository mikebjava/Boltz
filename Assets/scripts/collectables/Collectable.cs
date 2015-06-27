using UnityEngine;
using System.Collections;
using System;

public class Collectable : MonoBehaviour
{

    #region Editor Variables
    public bool DestroyOnCollect = true;
    public bool PlaySoundOnCollect = true;
    public AudioClip CollectionSound;
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
            CollectableCollectedEventArgs args = new CollectableCollectedEventArgs();
            args.Collector = coll.gameObject;
            OnCollected(this, args);

            if (PlaySoundOnCollect && CollectionSound != null)
            {
                AudioSource.PlayClipAtPoint(CollectionSound, transform.position);
            }

            if (DestroyOnCollect)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
