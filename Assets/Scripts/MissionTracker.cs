using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTracker
{
    public enum LEVEL {
        TALK_TO_COOKIE,
        TALK_TO_DANTE
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
