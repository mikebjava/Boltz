using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class WASDMovement : MonoBehaviour
{
    #region Component Variables
    public float MovementSpeed;
    public TargetAxis axis = TargetAxis.HORIZONTAL;
    #endregion

    public enum TargetAxis
    {
        HORIZONTAL, VERTICAL, BIDIRECTIONAL
    }

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool isFacingRight = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        if (rb2d != null)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            if (x != 0)
            {
                isFacingRight = (x > 0);
            }

            if (isFacingRight)
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z));
            }

            if (axis == TargetAxis.HORIZONTAL)
            {
                rb2d.AddForce(new Vector2(x, 0).normalized * MovementSpeed);
                anim.SetFloat("xspeed", Mathf.Abs(x));
            }
            else if (axis == TargetAxis.VERTICAL)
            {
                rb2d.AddForce(new Vector2(0, y).normalized * MovementSpeed);
                anim.SetFloat("yspeed", Mathf.Abs(y));
            }
            else
            {
                rb2d.AddForce(new Vector2(x, y).normalized * MovementSpeed);
                anim.SetFloat("xspeed", Mathf.Abs(x));
                anim.SetFloat("yspeed", Mathf.Abs(y));
            }


        }
    }
}
