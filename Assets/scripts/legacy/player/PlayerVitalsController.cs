using UnityEngine;
using System;
using System.Collections;

public class PlayerVitalsController : MonoBehaviour
{

    #region Editor Variables
    public bool DrawVitals = true;
    public Texture2D healthWholeImage;
    public Texture2D healthPartialImage;
    public int maxHealth = 6;
    public int minHealth = 0;
    public int currentHealth = 6;
    public float UIScalarValue = 0.1f;
    public float hittimer = 2.0f;
    #endregion

    #region Getters/Setters
    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = Mathf.Clamp(value, minHealth, maxHealth);
        }
    }
    #endregion

    #region Events
    public event EventHandler PlayerHurtEvent;
    public virtual void OnPlayerHurt(EventArgs e)
    {
        EventHandler handler = PlayerHurtEvent;
        if (handler != null)
        {
            handler(this, e);
        }
    }
    #endregion

    private bool hurtSwitch = false;
    private float nextHit = 0.0f;

    public void Hurt(int damage)
    {
        if (hurtSwitch)
        {
            return;
        }
        else
        {
            CurrentHealth -= damage;
            nextHit = Time.time + hittimer;
            hurtSwitch = true;
            PlayerHurtEvent(this, new EventArgs());
        }
    }

    void FixedUpdate()
    {
        if (hurtSwitch)
        {
            if (nextHit <= Time.time)
            {
                hurtSwitch = false;
            }
        }
    }

    void OnGUI()
    {
        if (DrawVitals)
        {
            Rect r = new Rect(0, 0, Screen.width, Screen.height);
            GUILayout.BeginArea(r);
            GUILayout.BeginHorizontal();

            int wholeHearts = currentHealth / 2;
            int halfHearts = currentHealth % 2;

            for (int i = 0; i < wholeHearts; i++)
                GUILayout.Label(healthWholeImage, GUILayout.Width((int)(Screen.width * UIScalarValue)), GUILayout.Height((int)(Screen.height * UIScalarValue)));

            for (int i = 0; i < halfHearts; i++)
                GUILayout.Label(healthPartialImage, GUILayout.Width((int)(Screen.width * UIScalarValue)), GUILayout.Height((int)(Screen.height * UIScalarValue)));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
    }

}
