using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lader : MonoBehaviour {

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.GetComponentInParent<CharacterController>() != null)
        {
            hit.GetComponentInParent<PlayerMovement>().groundMode = false;
            Debug.Log("hit");
        }
    }
    private void OnTriggerExit(Collider hit)
    {
        if (hit.GetComponentInParent<CharacterController>() != null)
        {
            hit.GetComponentInParent<PlayerMovement>().groundMode = true;
        }
    }
}
