using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    public GameObject bullet;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    private BulletLogic shoot()
    {
        GameObject newObject = Instantiate(bullet) as GameObject;
        BulletLogic bl = newObject.GetComponent<BulletLogic>() as BulletLogic;
        bl.speed = 250;
        return bl;
    }
}
