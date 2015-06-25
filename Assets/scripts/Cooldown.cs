using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


public class Cooldown
{

    private Stopwatch timer;
    private float cooldownMS;
    private float lastTime;

    public Cooldown(float cooldown)
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

