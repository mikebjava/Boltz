using UnityEngine;
using System.Collections;

public class DoorComponent : ConnectedComponent
{
    private BoxCollider2D box;

    void Start()
    {
        box = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
        if (box == null)
        {
            Debug.LogWarning("Rigidbody not found");
        }
    }

    void Update()
    {

    }

    public override void powerOn()
    {
        box.enabled = false;
    }

    public override void powerOff()
    {
        box.enabled = true;
    }
}
