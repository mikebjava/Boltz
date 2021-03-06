﻿using UnityEngine;
using System.Collections;
using System.Diagnostics;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpHandler : MonoBehaviour
{

    #region Editor Variables
    public KeyCode jumpKey = KeyCode.Space;
    public float jumpHeight = 10f;
    public float jumpCooldown = 1000;
    public bool useJumpCooldown = true;
    public bool isGrounded = false;
    public CircleCollider2D groundCheck;
    public float offsetX = 0;
    public float offsetY = 0;
    public LayerMask defineGround;
    public AudioClip JumpSound;
    #endregion

    private ClimbingController climbingController;
    private Animator animator;
    private Rigidbody2D rb2d;
    private float lastJump = 0;
    private Stopwatch jumpTimer;

    void Start()
    {
        climbingController = GameController.Instance().Boltz.GetComponent<ClimbingController>() as ClimbingController;
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        jumpTimer = new Stopwatch();
        jumpTimer.Start();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(new Vector2(groundCheck.transform.position.x + offsetX, groundCheck.transform.position.y + offsetY), groundCheck.radius, defineGround);
        animator.SetBool("isGrounded", isGrounded);

        if (Input.GetKey(jumpKey) && (isGrounded || climbingController.IsClimbing))
        {
            if (useJumpCooldown)
            {
                if (!IsOnCooldown())
                {
                    lastJump = jumpTimer.ElapsedMilliseconds;
                    Jump();
                }
            }
            else
            {
                lastJump = jumpTimer.ElapsedMilliseconds;
                Jump();
            }
        }
    }

    private void Jump()
    {
        if (rb2d != null)
        {
            rb2d.AddForce(new Vector2(0, jumpHeight));
            isGrounded = false;

            AudioSource source = GameController.Instance().Boltz.GetComponent<AudioSource>();
            source.PlayOneShot(JumpSound, 1.0f);

            climbingController.Detach();
        }
    }

    private bool IsOnCooldown()
    {
        return ((jumpTimer.ElapsedMilliseconds - lastJump) <= jumpCooldown);
    }
}
