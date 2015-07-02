using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AIGyro : MonoBehaviour
{

    #region Editor Variables
    public EdgeCollider2D LeftCollider;
    public EdgeCollider2D RightCollider;
    public float MovementSpeed = 5.0f;
    public AIDirection Direction;
    #endregion

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            if (Direction == AIDirection.LEFT)
            {
                rb.AddForce(MovementSpeed * Vector3.left);
            }
            else if (Direction == AIDirection.RIGHT)
            {
                rb.AddForce(MovementSpeed * Vector3.right);
            }
        }
    }


    void OnColliderEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.tag);
        if (coll.contacts[0].collider == LeftCollider)
        {
            Direction = AIDirection.RIGHT;
            Debug.Log("tete");
        }
        else if (coll.contacts[0].collider == RightCollider)
        {
            Direction = AIDirection.LEFT;
            Debug.Log("tetdde");
        }
    }

}

