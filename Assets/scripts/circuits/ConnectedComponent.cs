using UnityEngine;
using System.Collections;

public abstract class ConnectedComponent : MonoBehaviour
{

    private bool isPowered;

    public void updateComponent(bool isPowered)
    {
        switch (isPowered)
        {
            case true:
                powerOn();
                break;
            case false:
                powerOff();
                break;
            default:
                break;
        }
    }

    public abstract void powerOn();
    public abstract void powerOff();
}
