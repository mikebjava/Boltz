using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HealEventArgs : EventArgs
{
    public int Amount { get; set; }
    public int CurrentLife { get; set; }
    public GameObject Source { get; set; }
    public GameObject Receiver { get; set; }
}
