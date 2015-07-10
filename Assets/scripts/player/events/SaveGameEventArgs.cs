using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SaveGameEventArgs : EventArgs
{
    public GameObject Player { get; set; }
    public int SaveLevel { get; set; }
    public string LevelName { get; set; }
}
