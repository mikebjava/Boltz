using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {
    public float speed;
    private Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () 
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
        if(rigidbody == null)
        {
            Debug.LogWarning("Rigidbody for bullet not found");
        }
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 spd = new Vector2(speed, 0);
        rigidbody.AddForce(spd);
	}
}
