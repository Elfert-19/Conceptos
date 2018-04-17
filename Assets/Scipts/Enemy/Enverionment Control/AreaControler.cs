using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaControler : MonoBehaviour {
    public List<SectorControl> sectors;
    public int playerInArea;
    public List<Transform> areaWaypoints;
    public int areaWaypointsAmount;
    public int enemyAmount;
    public int enemySmall;
    public int enemyMedium;
    public int enemmyBig;

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

    // Setea la cantidad y el tipo de entidades que pueblan el area;
    public void ControlArea()
    {
        playerInArea = 0;
        enemyAmount = 0;
        enemmyBig = 0;
        enemyMedium = 0;
        enemySmall = 0;
        foreach (SectorControl sector in sectors)
        {
            playerInArea += sector.playersDetected.Count;
            enemyAmount += sector.enemysDetected.Count;
            foreach (EnemyMovement enemy in sector.enemysDetected)
            {
                EnemyType enemyType = enemy.GetComponent<EnemyType>();
                if(enemyType.enemySize == EnemyType.Type.Small)
                {
                    enemySmall += 1;
                }
                if (enemyType.enemySize == EnemyType.Type.Medium)
                {
                    enemyMedium += 1;
                }
                if (enemyType.enemySize == EnemyType.Type.Big)
                {
                    enemmyBig += 1;
                }
            }
        }
    }

    // Devuelve un booleano si la el sector tiene un jugador;
    public bool IsDangerZone(SectorControl sector)
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
