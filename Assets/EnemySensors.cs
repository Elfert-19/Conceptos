using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensors : MonoBehaviour {
    public float visionRange;
    public float angleVision;
    public LayerMask visionLayer;
    public float audioRange;
    public float maxShotSoundRange;
    public float maxStepSoundRange;
    public LayerMask audioLayer;
    Collider[] visionDetection;
    public List<Collider> visibleObjetives;
    Collider[] audioDetection;
    public List<Collider> heardObjetives;
    List<Collider> ambientalDetecion;

    private void Awake()
    {
        visionDetection = new Collider[25];
        audioDetection = new Collider[8];
    }

    private void FixedUpdate()
    {
        Vision();
        Hearding();
    }

    private void OnTriggerEnter(Collider hit)
    {
        for (int i = 0; i < ambientalDetecion.Count; i++)
        {
            if(hit.GetInstanceID().Equals(ambientalDetecion[i].GetInstanceID()))
            {
                break;
            }
            else
            {
                ambientalDetecion.Add(hit);
            }
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        for (int i = 0; i < ambientalDetecion.Count; i++)
        {
            if (hit.GetInstanceID().Equals(ambientalDetecion[i].GetInstanceID()))
            {
                ambientalDetecion.Remove(ambientalDetecion[i]);
            }
        }
    }

    public void Vision()
    {
        Physics.OverlapSphereNonAlloc(transform.position, visionRange, visionDetection, visionLayer);
        for (int i = 0; i < visionDetection.Length; i++)
        {
            Vector3 targetDirection = Vector3.Normalize(visionDetection[i].transform.position - transform.position);
            float dot = Vector3.Dot(transform.forward, targetDirection);
            if(dot >= angleVision)
            {
                for (int o = 0; o < visibleObjetives.Count; o++)
                {
                    if(visionDetection[i].GetInstanceID().Equals(visibleObjetives[o].GetInstanceID()))
                    {
                        break;
                    }
                    else
                    {
                        visibleObjetives.Add(visionDetection[i]);
                    }
                }
            }
            else
            {
                for (int o = 0; o < visibleObjetives.Count; o++)
                {
                    if (visionDetection[i].GetInstanceID().Equals(visibleObjetives[o].GetInstanceID()))
                    {
                        visibleObjetives.Remove(visionDetection[i]);
                    }
                }
            }
        }
    }

    public void Hearding()
    {
        Physics.OverlapSphereNonAlloc(transform.position, audioRange, audioDetection, audioLayer);
        for (int i = 0; i < audioDetection.Length; i++)
        {
            if(audioDetection[i].GetComponent<PlayerMovement>() & audioDetection[i].GetComponent<Shooter>())
            {
                PlayerMovement movement = audioDetection[i].GetComponent<PlayerMovement>();
                Shooter weapon = audioDetection[i].GetComponent<Shooter>();
                float soundSource = Vector3.Distance(transform.position, audioDetection[i].transform.position);
                if (movement.makingSound == true & soundSource <= maxStepSoundRange)
                {
                    heardObjetives.Add(audioDetection[i]);
                }
                if(weapon.makingSound == true & soundSource <= maxShotSoundRange)
                {
                    heardObjetives.Add(audioDetection[i]);
                }
            }
        }
    }
}
