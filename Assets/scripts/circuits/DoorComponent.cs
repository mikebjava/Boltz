using UnityEngine;
using System.Collections;

public class DoorComponent : ConnectedComponent {
    private BoxCollider2D box;
	// Use this for initialization
	void Start () {
        box = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
        if(box == null)
        {
            Debug.LogWarning("Rigidbody not found");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public override void powerOn()
    {
        //power on code
        box.enabled = false;
    }
    public override void powerOff()
    {
        //power off code
        box.enabled = true;
    }
}
