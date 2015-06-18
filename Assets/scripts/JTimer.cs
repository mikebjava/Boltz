using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class JTimer : MonoBehaviour {
    public float timeLeft;
    public Text time;
    public bool startOnPlay;
    private bool started;
    //public Text text;

    #region Events
    public event EventHandler<TimerEventArgs> timeChanged;
    public event EventHandler<TimerEventArgs> timerStarted;
    public event EventHandler<TimerEventArgs> timerStopped;
    public virtual void onTimeChanged(object obj, TimerEventArgs args)
    {
        if(timeChanged != null)
        {
            timeChanged(obj, args);
        }
    }

    public virtual void onTimerStarted(object obj, TimerEventArgs args)
    {
        if(timerStarted != null)
        {
            timerStarted(obj, args);
        }
    }
    public virtual void onTimerStopped(object obj, TimerEventArgs args)
    {
        if (timerStopped != null)
        {
            timerStarted(obj, args);
        }
    }
    #endregion

    // Use this for initialization
	void Start () 
    {
        if(time == null)
        {
            Debug.LogWarning("Text component for timer was not found. This may cause errors.");
        } else if (startOnPlay)
        {
            startTimer(timeLeft);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (started)
        {
            timeLeft -= Time.deltaTime;
            time.text = "Time Left: " + (int)timeLeft;
            timeChange();
        }
    }

    #region Timer Methods
    public void startTimer(float time)
    {
        timeLeft = time;
        TimerEventArgs args = new TimerEventArgs();
        args.Time = time;
        started = true;
        onTimerStarted(this, args);
    }
    public void stopTimer()
    {
        TimerEventArgs args = new TimerEventArgs();
        args.Time = timeLeft;
        started = false;
        onTimerStopped(this, args);
    }
    public void addTime(float time)
    {
        timeLeft += time;
        timeChange();
    }
    public void removeTime(float time)
    {
        timeLeft -= time;
        timeChange();
    }
    private void timeChange()
    {
        TimerEventArgs args = new TimerEventArgs();
        args.Time = timeLeft;
        onTimeChanged(this, args);
    }
    #endregion
}
