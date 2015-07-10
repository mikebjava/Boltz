
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameSaveController : MonoBehaviour
{
    private int levelID;
    #region Events
    public event EventHandler<SaveGameEventArgs> Saved;
    public virtual void onSaved(object obj, SaveGameEventArgs args)
    {
        if(Saved != null)
        {
            Saved(obj, args);
        }
    }
    #endregion

    void Start()
    {
        levelID = Application.loadedLevel;
    }

    public void CreateSaveFile()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + "/saveGame.slf");
        bf.Serialize(fs, levelID);
        fs.Close();
        SaveGameEventArgs args = new SaveGameEventArgs();
        args.Player = null;
        args.LevelName = null;
        args.SaveLevel = levelID;
        onSaved(this, args);
    }
}
