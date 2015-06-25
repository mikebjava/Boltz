using UnityEngine;
using System.Collections;

public class DoorComponent : ConnectedComponent
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogWarning("A door was unable to find it's animator. This may cause problems.");
        }
    }

    public override void powerOn()
    {
        animator.SetBool("isOpen", true);
    }

    public override void powerOff()
    {
        animator.SetBool("isOpen", false);
    }
}
