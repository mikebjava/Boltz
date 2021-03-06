﻿using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour
{
    #region Editor Variables
    public string NextLevel;
    #endregion

    private static GameController instance;

    #region Player Properties
    public GameObject Boltz;
    #endregion
    #region Game Mechanics
    public GameObject UI;
    public GameObject OverlaySpace;
    public GameObject StatusDisplay;
    public TimerDisplay TimerDisplay;
    public LifeDisplay LifeDisplay;
    public ScoreDisplay ScoreDisplay;
    #endregion

    #region Events
    public event EventHandler PreWin;
    public virtual void OnPreWin(object obj, EventArgs args)
    {
        if (PreWin != null)
        {
            PreWin(obj, args);
        }
    }

    public event EventHandler PostWin;
    public virtual void OnPostWin(object obj, EventArgs args)
    {
        if (PostWin != null)
        {
            PostWin(obj, args);
        }
    }
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
            instance.InitInstances();
            Destroy(gameObject);
            return;
        }

        InitInstances();
    }

    public void InitInstances()
    {
        #region Player Properties
        Boltz = GameObject.FindGameObjectWithTag("Player");
        if (Boltz == null)
        {
            Debug.LogWarning("Player instance not found! This may cause problems with the game.");
        }


        #endregion
        #region Game Mechanics
        #region Find and bind the UI
        UI = GameObject.FindWithTag("UI");
        if (UI == null)
        {
            Debug.LogWarning("GameController was unable to find the UI. This may cause problems.");
        }
        else
        {
            #region Find and bind the OverlaySpace
            OverlaySpace = UI.transform.FindChild("Overlay Space").gameObject;
            if (OverlaySpace == null)
            {
                Debug.LogWarning("GameController was unable to find the Overlay Space. This may cause problems.");
            }
            else
            {
                #region Find and bind the StatusDisplay
                StatusDisplay = OverlaySpace.transform.FindChild("Status Display").gameObject;
                if (StatusDisplay == null)
                {
                    Debug.LogWarning("GameController was unable to find the Status Display. This may cause problems.");
                }
                else
                {
                    #region Find and bind the various status displays (LifeDisplay, TimeDisplay, etc)
                    TimerDisplay = StatusDisplay.transform.FindChild("Timer Display").gameObject.GetComponent<TimerDisplay>() as TimerDisplay;
                    if (TimerDisplay == null)
                        Debug.LogWarning("GameController was unable to find the Timer Display. This may cause problems.");


                    LifeDisplay = StatusDisplay.transform.FindChild("Life Display").gameObject.GetComponent<LifeDisplay>() as LifeDisplay;
                    if (LifeDisplay == null)
                        Debug.LogWarning("GameController was unable to find the Life Display. This may cause problems.");


                    ScoreDisplay = StatusDisplay.transform.FindChild("Score Display").gameObject.GetComponent<ScoreDisplay>() as ScoreDisplay;
                    if (ScoreDisplay == null)
                        Debug.LogWarning("GameController was unable to find the Score Display. This may cause problems.");
                    #endregion
                }
                #endregion
            }
            #endregion
        }
        #endregion
        #endregion
    }

    public static GameController Instance()
    {
        return instance;
    }

    public void TriggerWin()
    {
        PreWin(this, new EventArgs());
        Application.LoadLevel(NextLevel);
        PostWin(this, new EventArgs());
    }

    public static bool IsValidGame()
    {
        return (Instance() != null && Instance().Boltz != null);
    }
}