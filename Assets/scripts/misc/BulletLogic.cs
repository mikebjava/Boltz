using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class BulletLogic : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidbody;
    private int cleanUpTime = 5000; //clean up time(in milliseconds)
    private bool deadBullet;
    private Stopwatch timer;
    // Use this for initialization
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
        timer = new Stopwatch();
        if (rigidbody == null)
        {
            UnityEngine.Debug.LogWarning("Rigidbody for bullet not found");
        }
    }

    void FixedUpdate()
    {
        if (!deadBullet)
        {
            Vector2 spd = new Vector2(speed, 0);
            rigidbody.AddForce(spd);
        }
    }

    void Update()
    {
        if(deadBullet && timer.ElapsedMilliseconds >= cleanUpTime)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (rigidbody != null)
        {
            Vector2 vel = new Vector2(0, 0);
            rigidbody.velocity = vel;
            deadBullet = true;
            timer.Start();
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
