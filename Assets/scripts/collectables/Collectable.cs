using UnityEngine;
using System.Collections;
using System;

public class Collectable : MonoBehaviour
{

    #region Editor Variables
    public bool DestroyOnCollect = true;
    public bool PlaySoundOnCollect = true;
    public AudioClip CollectionSound;
    public bool UsePitchVariation = true;
    public float PitchLowRange = 0.7f;
    public float PitchHighRange = 1.0f;
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

            AudioSource source = GameController.Instance().Boltz.GetComponent<AudioSource>() as AudioSource;
            if (source == null && PlaySoundOnCollect)
            {
                Debug.LogWarning("AudioSource not found while trying to play a Collectable's OnCollect sound.");
            }

            if (source != null && PlaySoundOnCollect && CollectionSound != null)
            {
                if (UsePitchVariation)
                {
                    source.pitch = UnityEngine.Random.Range(PitchLowRange, PitchHighRange);
                }

                source.PlayOneShot(CollectionSound, 1.0f);
            }

            if (DestroyOnCollect)
                Destroy(this.gameObject);

        }
    }
}
