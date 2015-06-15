using UnityEngine;
using System.Collections;


public class GameController : MonoBehaviour
{
    private static GameController instance;

    #region Player Properties
    public GameObject boltzInstance;
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

        boltzInstance = GameObject.FindGameObjectWithTag("Player");

        if (boltzInstance == null)
        {
            Debug.LogWarning("Player instance not found! This may cause problems with the game.");
        }
    }

    public static GameController Instance()
    {
        return instance;
    }
}