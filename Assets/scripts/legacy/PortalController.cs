using UnityEngine;
using System.Collections;
using System;

public class PortalController : MonoBehaviour
{

    #region Events
    public event EventHandler WinStateTriggeredEvent;
    public virtual void OnWinStateTriggeredEvent(EventArgs e)
    {
        EventHandler handle = WinStateTriggeredEvent;
        if (handle != null)
        {
            WinStateTriggeredEvent(this, new EventArgs());
        }
    }
    #endregion

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.transform.parent != null)
        {
            if (col.gameObject.transform.parent.tag == "Player")
            {
                GameController.Instance().TriggerWin();
            }
        }
    }
}
