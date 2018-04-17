using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorControl : MonoBehaviour {

    public List<PlayerClass> playersDetected;
    public List<Transform> waypoints;
    public List<EnemyMovement> enemysDetected;

    // Carga la lista con las entidades que entraron al sector;
    private void OnTriggerEnter(Collider detection)
    {
        if(detection.GetComponent<PlayerClass>() != null)
        {
            playersDetected.Add(detection.GetComponent<PlayerClass>());
        }
        if (detection.GetComponent<EnemyMovement>() != null)
        {
            enemysDetected.Add(detection.GetComponent<EnemyMovement>());
        }
    }

    // Descarga la lista de las entidades que avandonario el sector;
    private void OnTriggerExit(Collider detection)
    {
        if(detection.GetComponent<PlayerClass>() != null)
        {
            playersDetected.Remove(detection.GetComponent<PlayerClass>());
        }
        if (detection.GetComponent<EnemyMovement>() != null)
        {
            enemysDetected.Remove(detection.GetComponent<EnemyMovement>());
        }
    }
}
