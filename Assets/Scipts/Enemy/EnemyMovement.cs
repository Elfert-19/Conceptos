using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    public bool canMove;
    List<Transform> areaWaypoints;
    List<Transform> sectorWaypoints;
    List<Transform> nodeWaypoints;
    public float speed;

    public void Stun(float duration)
    {
        canMove = false;
        Invoke("Recovery", duration);
    }

    public void Recovery()
    {
        canMove = true;
    }
    
}
