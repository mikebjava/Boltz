using UnityEngine;
using System.Collections;

public class FeetAudioController : MonoBehaviour
{
    #region Editor Variables
    public AudioClip JumpLandSound;
    #endregion

    private AudioSource source;

    void Start()
    {
        source = GameController.Instance().Boltz.GetComponent<AudioSource>();
        if (source == null)
        {
            Debug.LogWarning("FeetAudioController was unable to find the player's AudioSource.");
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (source != null)
        {
            if (coll.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                source.pitch = 1.0f;
                source.PlayOneShot(JumpLandSound, 1.0f);
            }
        }
    }
}
