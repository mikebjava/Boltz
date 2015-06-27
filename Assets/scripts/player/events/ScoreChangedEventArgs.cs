using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ScoreChangedEventArgs : EventArgs
{
    public int ValueChanged { get; set; }
    public int PreviousScore { get; set; }
    public int CurrentScore { get; set; }
}

