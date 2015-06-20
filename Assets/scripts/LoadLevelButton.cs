using UnityEngine;
using System.Collections;

public class LoadLevelButton : MonoBehaviour
{

    #region Editor Variables
    public string LevelName;
    #endregion

    public void OnClick()
    {
        Application.LoadLevel(LevelName);
    }

}
