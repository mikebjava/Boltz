using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour
{
    #region Editor Variables
    public GameObject attachedGameObject;
    public bool isActive = false;
    #endregion

    private ConnectedComponent connectedComp;
    private Animator animator;
    private Cooldown cd;

    void Start()
    {
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
        }
        else
        {
            isActive = false;
            if (connectedComp != null)
            {
                connectedComp.updateComponent(isActive);
            }
            animator.SetBool("isOn", isActive);
        }
    }

}
