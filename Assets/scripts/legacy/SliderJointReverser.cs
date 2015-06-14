using UnityEngine;
using System.Collections;

public class SliderJointReverser : MonoBehaviour
{

    private SliderJoint2D slider;

    void Start()
    {
        slider = GetComponent<SliderJoint2D>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Blag");
        if (collision.collider.gameObject.transform.parent != null)
        {
            if (collision.collider.gameObject.transform.parent.tag == "Player")
            {
                return;
            }
        }

        if (slider != null)
        {
            JointMotor2D motor = slider.motor;
            motor.motorSpeed *= -1;
            slider.motor = motor;
        }

    }
}
