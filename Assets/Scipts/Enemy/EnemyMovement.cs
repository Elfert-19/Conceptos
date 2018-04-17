using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    public bool canMove;
    List<Transform> areaWaypoints;
    List<Transform> sectorWaypoints;
    public float speed;
    AreaControler areaCont;
    MapController mapCont;
    NavMeshAgent navMesh;
    public Vector3 nextWaypointRandom;
    public Vector3 nextArea;
    public bool inDestination;
    public float maxDistanceToDestination;

    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Consigue la informacion del area y del mundo;
    private void OnTriggerEnter(Collider hit)
    {
        if(hit.GetComponent<AreaControler>() != null)
        {
            areaCont = hit.GetComponentInParent<AreaControler>();
            mapCont = areaCont.GetComponentInParent<MapController>();
        }
    }

    // Se aplia una paralisis al movimiento;
    public void Stun(float duration)
    {
        canMove = false;
        Invoke("Recovery", duration);
    }

    // Termina la paralisis del movimiento;
    public void Recovery()
    {
        canMove = true;
    }
    
    // Se traslada a un waypoint aleatorio dentro del area que se encuentra;
    public Vector3 NextPositionRandom()
    {
        int nextWaypointNumbre = Random.Range(0, areaCont.areaWaypoints.Count);
        return nextWaypointRandom = areaCont.areaWaypoints[nextWaypointNumbre].position;
    }

    // Se traslada a una posicion en particular y controla si esta dentro de la distancia maxima a la posicion destino;
    public void MoveToTarget(Vector3 target)
    {
        if (canMove == true)
        {
            navMesh.Move(target);
            if(Vector3.Distance(transform.position,target) < maxDistanceToDestination)
            {
                inDestination = true;
            }
            else
            {
                inDestination = false;
            }
        }
    }

    // Cambia de area y se mueve a la siguien o la anterio, tiene una chance de quedarse en la misma area, pero siempre a un waypoint al azar;
    public Vector3 ChangeArea()
    {
        int indexArea = Random.Range(-1, 1);
        int indexSector = Random.Range(0, mapCont.areasAvalides[indexArea].sectors.Count);
        int indexWaypoint = Random.Range(0, mapCont.areasAvalides[indexArea].sectors[indexSector].waypoints.Count);
        return nextArea = mapCont.areasAvalides[indexArea].sectors[indexSector].waypoints[indexWaypoint].position;
    }

    // Aplica un dash en alguna direccion dada, con una fuerza dada;
    public void Dash(Vector3 direction, float dashforce)
    {
        transform.Translate(direction * dashforce * Time.deltaTime);
    }

    // Cambia a un area y sector donde nose encuentre ningun jugador;
    public Vector3 EscapeVector()
    {
        int indexArea = Random.Range(-1, 1);
        int indexSector = Random.Range(0, mapCont.areasAvalides[indexArea].sectors.Count);
        int indexWaypoint = Random.Range(0, mapCont.areasAvalides[indexArea].sectors[indexSector].waypoints.Count);

        if (mapCont.areasAvalides[indexArea].IsDangerZone(mapCont.areasAvalides[indexArea].sectors[indexSector]) == false)
        {
            return nextArea = mapCont.areasAvalides[indexArea].sectors[indexSector].waypoints[indexWaypoint].position;
        }
        else
        {
            ChangeArea();
        }

        return nextArea = mapCont.areasAvalides[indexArea].sectors[indexSector].waypoints[indexWaypoint].position;
    }
}
