using UnityEngine;
using System.Collections;

public class MetalCrate : MonoBehaviour
{

    #region Editor Variables
    public AudioClip CollisionSound;
    public float VelocityThreshold = 5.0f;
    public float PitchLowRange = 0.7f;
    public float PitchHighRange = 1.0f;
    #endregion

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        if (source == null)
        {
            Debug.LogWarning("MetalCrate was unable to find an AudioSource.");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (source != null)
        {
            if (coll.relativeVelocity.magnitude > VelocityThreshold)
            {
                source.pitch = UnityEngine.Random.Range(PitchLowRange, PitchHighRange);
                source.PlayOneShot(CollisionSound, 1.0f);
            }
        }
    }

}
