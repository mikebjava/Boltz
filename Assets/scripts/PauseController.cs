using UnityEngine;
using System.Collections;
using System;

public class PauseController : MonoBehaviour
{
    #region Editor Variables
    public KeyCode PauseKey = KeyCode.Escape;
    public AudioClip PauseSound;
    public bool PausingEnabled = true;
    #endregion

    #region Events
    public event EventHandler Paused;
    public virtual void OnPause(object obj, EventArgs args)
    {
        if (Paused != null)
        {
            Paused(obj, args);
        }
    }

    public event EventHandler Unpaused;
    public virtual void OnUnpause(object obj, EventArgs args)
    {
        if (Unpaused != null)
        {
            Unpaused(obj, args);
        }
    }
    #endregion

    public bool IsPaused { get { return pauseSwitch; } set { this.pauseSwitch = value; } }

    private Cooldown pauseCD;
    private bool pauseSwitch = false;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        if (source == null)
        {
            Debug.LogWarning("PauseController was unable to locate an AudioSource. This may cause problems.");
        }
        pauseCD = new Cooldown(250);
    }

    void Update()
    {
        if (Input.GetKeyDown(PauseKey))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (PausingEnabled)
        {
            if (pauseCD.Available())
            {
                if (pauseSwitch)
                {
                    pauseSwitch = false;
                    Time.timeScale = 1;
                    OnUnpause(this, new EventArgs());
                    source.pitch = 0.9f;
                    source.PlayOneShot(PauseSound);
                }
                else
                {
                    pauseSwitch = true;
                    Time.timeScale = 0;
                    OnPause(this, new EventArgs());
                    source.pitch = 1.0f;
                    source.PlayOneShot(PauseSound);
                }
            }
        }
    }
}
