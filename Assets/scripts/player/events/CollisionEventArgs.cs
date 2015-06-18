using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CollisionEventArgs : EventArgs 
{
    public Collider2D triggerObject { get; set; }

    public Collision2D collisionObject { get; set; }

    public bool isTrigger { get; set; }
}
