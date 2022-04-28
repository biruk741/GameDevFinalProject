using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTracker
{
    public enum LEVEL {
        TALK_TO_COOKIE,
        TALK_TO_DANTE,
        PLAY_MATCHING,
        TALK_TO_DANTE_2,
        GO_TO_STUDENT_CENTER,
        TALK_TO_ISABELLE,
        GET_BLUE_PILL,
        TALK_TO_ISABELLE_2,
        LEAVE_STUDENT_CENTER,
        GO_TO_LIBRARY,
        TALK_TO_ASHLEY,
        PLAY_BOOKGAME,
        TALK_TO_ASHLEY2,
        LEAVE_LIBRARY,
        GO_TO_HFA,
        TALK_TO_MUSICIAN,
        PLAY_PIANO_GAME,
        TALK_TO_MUSICIAN2,
        LEAVE_HFA,
        GO_TO_DUNGEON,
        TALK_TO_BIRUK,
        PLAY_GAME,
        TALK_TO_BIRUK2,
        LEAVE_DUNGEON,
        GO_TO_INDY,
        TALK_TO_CA,
        PLAY_PING_PONG,
        TALK_TO_CA2,
        LEAVE_INDY


    }
    private static MissionTracker _instance;
    public static MissionTracker instance{
        get {
            if (_instance == null) {
                refresh();
            }
            return _instance;
        }
    }
    public static void refresh() {
        _instance = new MissionTracker();
    }

    public event System.Action onLevelChanged;
    private const string HEALTH_KEY = "LEVEL";
    public LEVEL level
    {
        get
        {
            return (LEVEL) PlayerPrefs.GetInt(HEALTH_KEY);
        }
        set
        {
            PlayerPrefs.SetInt(HEALTH_KEY, (int) value);
            onLevelChanged?.Invoke();
        }
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("Tools/Reset Player Prefs")]
    public static void ResetStats()
    {
        PlayerPrefs.DeleteAll();
    }
#endif
}
