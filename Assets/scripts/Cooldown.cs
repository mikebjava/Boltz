using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


public class Cooldown
{

    public int CooldownTime
    {
        get
        {
            return cooldownMS;
        }
        set
        {
            this.cooldownMS = value;
        }
    }

    private Stopwatch timer;
    private int cooldownMS;
    private float lastTime;

    public Cooldown(int cooldown)
    {
        this.cooldownMS = cooldown;
        timer = new Stopwatch();
        timer.Start();
    }

    public bool Available()
    {
        if (timer.ElapsedMilliseconds - lastTime > cooldownMS)
        {
            lastTime = timer.ElapsedMilliseconds;
            return true;
        }
        return false;
    }
}

