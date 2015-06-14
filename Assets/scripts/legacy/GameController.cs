using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    #region Player Properties
    public GameObject playerBallInstance;
    public GameObject playerInstance;
    #endregion

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        playerInstance = GameObject.FindGameObjectWithTag("Player");
        playerBallInstance = playerInstance.transform.FindChild("Elemental Ball").gameObject;
    }

    public static GameController Instance()
    {
        return instance;
    }

    public void TriggerWin()
    {
        
    }

}
