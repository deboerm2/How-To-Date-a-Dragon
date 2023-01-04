using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventCard : MonoBehaviour
{
    [HideInInspector]
    public GameObject occupier = null;

    void OnTriggerEnter(Collider other)
    {
        if(occupier != null)
            occupier.GetComponent<DateCardEffects>().inTrigger = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (occupier == null)
        {
            occupier = other.gameObject;
            occupier.GetComponent<DateCardEffects>().inTrigger = true;
        }
        if (occupier != null && occupier.gameObject.GetComponent<DateCardEffects>().isPressed == false)
        {
            occupier.gameObject.transform.position = gameObject.transform.position;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(occupier!=null)
            occupier.GetComponent<DateCardEffects>().inTrigger = false;

        occupier = null;
    }
}
