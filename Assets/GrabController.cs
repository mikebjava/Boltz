using UnityEngine;
using System.Collections;

public class GrabController : MonoBehaviour
{

    #region Editor Variables
    public bool IsGrabbing = false;
    #endregion

    private DistanceJoint2D joint;
    private float prevMass = 0.0f;
    private bool prevFixedAngle = false;
    private GameObject grabbedObject;

    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
    }

    void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.LeftShift) && IsGrabbing)
        {
            Detach();
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        Rigidbody2D rb = coll.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null && coll.gameObject.tag == "Grippable" && !IsGrabbing && Input.GetKey(KeyCode.LeftShift))
        {
            Attach(rb);
        }
    }

    public void Attach(Rigidbody2D rb)
    {
        joint.connectedBody = rb;
        joint.enabled = true;
        IsGrabbing = true;
        this.prevMass = rb.mass;
        this.prevFixedAngle = rb.fixedAngle;
        rb.mass = 0.001f;
        rb.fixedAngle = true;
        this.grabbedObject = rb.gameObject;
    }

    public void Detach()
    {
        IsGrabbing = false;
        joint.enabled = false;
        grabbedObject.GetComponent<Rigidbody2D>().mass = prevMass;
        grabbedObject.GetComponent<Rigidbody2D>().fixedAngle = prevFixedAngle;
        grabbedObject = null;
    }

}
