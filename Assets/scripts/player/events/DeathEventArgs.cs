using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DeathEventArgs : EventArgs
{
    public GameObject Killer { get; set; }
    public GameObject Victim { get; set; }
}

