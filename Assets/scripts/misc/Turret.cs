using UnityEngine;
using System.Collections;
using System.Timers;
using System.Diagnostics;
public class Turret : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right
    };
    public float speed;
    public Direction dir;
    public int secondsPerShot;
    public GameObject bullet;
    private Stopwatch time;
        // Use this for initialization
    void Start()
    {
        time = new Stopwatch();
        time.Start();
        secondsPerShot += secondsPerShot * 1000;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time.ElapsedMilliseconds >= secondsPerShot)
        {
            shoot();
            time.Reset();
            time.Start();
        }
    }

    private BulletLogic shoot()
    {
        Vector3 pos = gameObject.transform.position;
        Quaternion q = gameObject.transform.rotation;
        GameObject newObject = Instantiate(bullet, pos, q) as GameObject;
        BulletLogic bl = newObject.GetComponent<BulletLogic>() as BulletLogic;
        if (dir == Direction.Right)
        {
            bl.speed = speed;
        }
        if (dir == Direction.Left)
        {
            bl.speed = -speed;
        } 
        return bl;
    }
}
