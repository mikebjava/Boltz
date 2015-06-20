using UnityEngine;
using System.Collections;

public class ObjectFollow : MonoBehaviour
{

    #region Component Variables
    public Transform transformToFollow;
    public float xMargin = 1f;
    public float yMargin = 1f;
    public float xSmooth = 8.0f;
    public float ySmooth = 8.0f;
    public float epsilon = 1.0f;
    public float xClamp = 10.0f;
    public float yClamp = 10.0f;
    public bool useClamp = false;
    public float jumpDistance = 15f;
    public bool useJumping = true;
    #endregion

    public enum Margin
    {
        X, Y
    }

    void FixedUpdate()
    {
        if (transformToFollow != null)
        {
            float xPan = transform.position.x;
            float yPan = transform.position.y;

            if (CheckMargin(Margin.X))
            {
                xPan = Mathf.Lerp(xPan, transformToFollow.position.x, xSmooth * Time.deltaTime);
            }

            if (CheckMargin(Margin.Y))
            {
                yPan = Mathf.Lerp(yPan, transformToFollow.position.y, ySmooth * Time.deltaTime);
            }

            if ((Mathf.Abs(xPan - transformToFollow.position.x) >= jumpDistance || Mathf.Abs(yPan - transformToFollow.position.y) >= jumpDistance) && useJumping)
            {
                xPan = transformToFollow.position.x;
                yPan = transformToFollow.position.y;
            }

            if (useClamp)
            {
                xPan = Mathf.Clamp(xPan, -xClamp, xClamp);
                yPan = Mathf.Clamp(yPan, -yClamp, yClamp);
            }

            transform.position = new Vector3(xPan, yPan, transform.position.z);
        }
    }


    private bool CheckMargin(Margin m)
    {
        if (m == Margin.X)
        {
            return Mathf.Abs(transform.position.x - transformToFollow.position.x) > xMargin;
        }
        else
        {
            return Mathf.Abs(transform.position.y - transformToFollow.position.y) > yMargin;
        }
    }

}
