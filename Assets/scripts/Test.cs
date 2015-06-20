using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{

    public bool explode = false;

    void FixedUpdate()
    {
        if (explode)
        {
            PointEffector2D p = gameObject.GetComponent<PointEffector2D>() as PointEffector2D;
            if (p != null)
            {
                p.enabled = true;

            }
        }
    }

    void LateUpdate()
    {
        if (explode)
        {
            Destroy(gameObject);
        }
    }
}
