using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class ClimbingController : MonoBehaviour
{

    #region Editor Variables
    public bool IsClimbing = false;
    public float ClimbCooldown = 250f;
    #endregion

    private HingeJoint2D hinge;
    private Stopwatch timer;
    private float lastGrabbed = 0f;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        hinge.enabled = false;
        timer = new Stopwatch();
        timer.Start();
    }

    void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.LeftShift) && IsClimbing)
        {
            Detach();
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Rigidbody2D rb = coll.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null && coll.gameObject.tag == "Rope" && !IsClimbing && Input.GetKey(KeyCode.LeftShift))
        {
            if (timer.ElapsedMilliseconds - lastGrabbed > ClimbCooldown)
                Attach(rb);
        }
    }

    public void Attach(Rigidbody2D rb)
    {
        hinge.connectedBody = rb;
        hinge.enabled = true;
        IsClimbing = true;
        lastGrabbed = timer.ElapsedMilliseconds;
    }

    public void Detach()
    {
        IsClimbing = false;
        hinge.enabled = false;
        lastGrabbed = timer.ElapsedMilliseconds;
    }
}
