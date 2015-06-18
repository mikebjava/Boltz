using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TimerDisplay : MonoBehaviour
{
    #region Editor Variables
    public float TimeLeft;
    public bool StartOnAwake;
    #endregion

    #region Events
    public event EventHandler<TimerEventArgs> timeChanged;
    public event EventHandler<TimerEventArgs> timerStarted;
    public event EventHandler<TimerEventArgs> timerStopped;
    public virtual void OnTimeChanged(object obj, TimerEventArgs args)
    {
        if (timeChanged != null)
        {
            timeChanged(obj, args);
        }
    }

    public virtual void OnTimerStarted(object obj, TimerEventArgs args)
    {
        if (timerStarted != null)
        {
            timerStarted(obj, args);
        }
    }
    public virtual void OnTimerStopped(object obj, TimerEventArgs args)
    {
        if (timerStopped != null)
        {
            timerStarted(obj, args);
        }
    }
    #endregion

    private bool started;
    private Text time;

    void Start()
    {
        time = GetComponent<Text>() as Text;
        if (time == null)
        {
            Debug.LogWarning("Text component for timer was not found. This may cause errors.");
        }
        else if (StartOnAwake)
        {
            Start(TimeLeft);
        }

        #region GameController Bindings
        if (GameController.Instance() != null)
        {
            GameController.Instance().TimerDisplay = this;
        }
        #endregion
    }

    void Update()
    {
        if (started)
        {
            TimeLeft -= Time.deltaTime;
            time.text = "Time Left: " + (int)TimeLeft;
            timeChange();
        }
    }

    #region Timer Methods
    public void Start(float time)
    {
        TimeLeft = time;
        TimerEventArgs args = new TimerEventArgs();
        args.Time = time;
        started = true;
        OnTimerStarted(this, args);
    }
    public void Stop()
    {
        TimerEventArgs args = new TimerEventArgs();
        args.Time = TimeLeft;
        started = false;
        OnTimerStopped(this, args);
    }
    public void Add(float time)
    {
        TimeLeft += time;
        timeChange();
    }
    public void Remove(float time)
    {
        TimeLeft -= time;
        timeChange();
    }
    private void timeChange()
    {
        TimerEventArgs args = new TimerEventArgs();
        args.Time = TimeLeft;
        OnTimeChanged(this, args);
    }
    #endregion
}
