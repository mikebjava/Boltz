using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.scripts.events
{
    public class DamagedEventArgs : EventArgs
    {
        public double Damage { get; set; }
        public GameObject DamagedObject { get; set; }
        public GameObject DamagingObject { get; set; }
    }
}
