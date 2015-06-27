using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour
{
    #region Editor Variables
    public GameObject attachedGameObject;
    public bool isActive = false;
    public AudioClip LeverOnSound;
    public AudioClip LeverOffSound;
    #endregion

    private ConnectedComponent connectedComp;
    private Animator animator;
    private Cooldown cd;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        if (source == null)
        {
            Debug.LogWarning("Lever was unable to find an AudioSource.");
        }

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogWarning("Animator not found on a Lever. This may cause problems.");
        }

        if (attachedGameObject != null)
        {
            connectedComp = attachedGameObject.GetComponent<ConnectedComponent>() as ConnectedComponent;
            if (connectedComp == null)
            {
                Debug.LogWarning("Component Script Not Found");
            }
        }
        else
        {
            Debug.LogWarning("No Attached GameObject To Switch");
        }

        cd = new Cooldown(1000);
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (cd.Available())
                    Flip();
            }
        }
    }

    private void Flip()
    {
        if (!isActive)
        {
            isActive = true;
            if (connectedComp != null)
            {
                connectedComp.updateComponent(isActive);
            }
            animator.SetBool("isOn", isActive);
            source.PlayOneShot(LeverOnSound);
        }
        else
        {
            isActive = false;
            if (connectedComp != null)
            {
                connectedComp.updateComponent(isActive);
            }
            animator.SetBool("isOn", isActive);
            source.PlayOneShot(LeverOffSound);
        }
    }

}
