using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public MissionTracker.LEVEL level;
    public Transform levelDestination;

    IEnumerator Start()
    {
        while(MinimapPointer.instance == null)
        {
            yield return null;
        }
        Refresh();
        MissionTracker.instance.onLevelChanged += Refresh;
    }

    private void Refresh()
    {
        bool levelMatch = MissionTracker.instance.level == level;
        print("Mission tacker instance = " + MissionTracker.instance.level + " and level = " + level);
        gameObject.SetActive(levelMatch);
        if(levelMatch && MinimapPointer.instance != null)
        {
            print("Minimappointer is not null = " + (levelMatch && MinimapPointer.instance != null) + " for mission " + level);
            MinimapPointer.instance.SetDestination(levelDestination);
        }
    }

    private void OnDestroy()
    {
        MissionTracker.instance.onLevelChanged -= Refresh;
    }
}
