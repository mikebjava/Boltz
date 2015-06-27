using UnityEngine;
using System.Collections;

public class DoorComponent : ConnectedComponent
{

    #region Editor Variables
    public AudioClip DoorOpenSound;
    public AudioClip DoorCloseSound;
    #endregion

    private Animator animator;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        if (source == null)
        {
            Debug.LogWarning("Door was unable to find an AudioSource.");
        }

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogWarning("A door was unable to find it's animator. This may cause problems.");
        }
    }

    public override void powerOn()
    {
        animator.SetBool("isOpen", true);
        source.PlayOneShot(DoorOpenSound);
    }

    public override void powerOff()
    {
        animator.SetBool("isOpen", false);
        source.PlayOneShot(DoorCloseSound);
    }
}
