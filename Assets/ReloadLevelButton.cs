using UnityEngine;
using System.Collections;

public class ReloadLevelButton : LoadLevelButton
{

    void Awake()
    {
        this.LevelName = Application.loadedLevelName;
    }

}
