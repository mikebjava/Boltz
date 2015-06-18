using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CollisionController : MonoBehaviour
{
    #region Events
    public event EventHandler<CollisionEventArgs> Collided;
    public virtual void onCollision(object obj, CollisionEventArgs args)
    {
        if(Collided != null)
        {
            Collided(obj, args);
        }
    }
    #endregion

    #region Collision Checking
    void OnTriggerEnter2D(Collider2D coll)
    {
        CollisionEventArgs args = new CollisionEventArgs();
        bool isTrigger = true;
        args.isTrigger = isTrigger;
        args.triggerObject = coll;
        args.collisionObject = null;
        onCollision(this, args);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        CollisionEventArgs args = new CollisionEventArgs();
        bool isTrigger = false;
        args.isTrigger = isTrigger;
        args.triggerObject = null;
        args.collisionObject = coll;
        onCollision(this, args);
    }
    #endregion
}
