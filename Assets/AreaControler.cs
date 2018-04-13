using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaControler : MonoBehaviour {
    public List<SectorControl> sectors;
    public int playerInArea;
    public List<Transform> areaWaypoints;
    public int areaWaypointsAmount;
    public int enemyAmount;

    private void Awake()
    {
        InvokeRepeating("ControlArea", 0, 1);
        for (int i = 0; i < sectors.Count; i++)
        {
            for (int i2 = 0; i2 < sectors[i].waypoints.Count; i2++)
            {
                areaWaypoints.Add(sectors[i].waypoints[i2]);
            }
        }
        areaWaypointsAmount = areaWaypoints.Count;
    }

    public void ControlArea()
    {
        playerInArea = 0;
        enemyAmount = 0;
        foreach (SectorControl sector in sectors)
        {
            playerInArea += sector.playersDetected.Count;
            enemyAmount += sector.enemysDetected.Count;
        }
    }

    public bool IsDangerZone(SectorControl sector, bool danger)
    {
        if(sector.playersDetected.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
