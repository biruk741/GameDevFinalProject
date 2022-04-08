using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public MissionTracker.LEVEL level;
    public Transform levelDestination;

    private void Awake()
    {
        Refresh();
        MissionTracker.instance.onLevelChanged += Refresh;
    }

    private void Refresh()
    {
        bool levelMatch = MissionTracker.instance.level == level;
        gameObject.SetActive(levelMatch);
        if(levelMatch && MinimapPointer.instance != null)
        {
            MinimapPointer.instance.SetDestination(levelDestination);
        }
    }

    private void OnDestroy()
    {
        MissionTracker.instance.onLevelChanged -= Refresh;
    }
}
