using UnityEngine;
using System;
using System.Collections;
using Assets.scripts;

public class PlayerElementalController : MonoBehaviour
{
    private ElementalType elementalType = ElementalType.None;

    #region Getters/Setters
    public ElementalType CurrentElement
    {
        get { return elementalType; }
        set { elementalType = value; ElementChangedEvent(this, new EventArgs()); }
    }
    #endregion

    #region Events
    public event EventHandler ElementChangedEvent;
    public virtual void OnElementChanged(EventArgs e)
    {
        EventHandler handler = ElementChangedEvent;
        if (handler != null)
        {
            handler(this, e);
        }
    }
    #endregion

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CurrentElement = ElementalType.Fire;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            CurrentElement = ElementalType.Water;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            CurrentElement = ElementalType.Earth;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            CurrentElement = ElementalType.Wind;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            CurrentElement = ElementalType.None;
        }
    }


}
