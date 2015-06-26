using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HealedEventArgs : EventArgs {
    public int healAmount { get; set; }
    public int CurrentLife { get; set; }
    public GameObject healer { get; set; }
    public GameObject healedObject { get; set; }


}
