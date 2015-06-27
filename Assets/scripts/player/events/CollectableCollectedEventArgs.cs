using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CollectableCollectedEventArgs : EventArgs
{
    public GameObject Collector { get; set; }
}

