using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpHandler : MonoBehaviour
{

    #region Component Variables
    public KeyCode jumpKey = KeyCode.Space;
    public float jumpHeight = 10f;
    public bool isGrounded = false;
    public GameObject groundCheck;
    public float offsetX = 0;
    public float offsetY = 0;
    public LayerMask defineGround;
    #endregion

    private Rigidbody2D rb2d;
    private float groundCheckRadius = 0.5f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(new Vector2(groundCheck.transform.position.x + offsetX, groundCheck.transform.position.y + offsetY), groundCheckRadius, defineGround);

        if (Input.GetKey(jumpKey) && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (rb2d != null)
        {
            rb2d.AddForce(new Vector2(0, jumpHeight));
            isGrounded = false;
        }
    }
}
