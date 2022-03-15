using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionCheck : MonoBehaviour
{
    public bool rightPosition = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Check"))
        {
            rightPosition = other.gameObject.GetComponent<Gizmo>().isFront;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Check"))
        {
            if (other.gameObject.GetComponent<Gizmo>().isFront)
            {
                rightPosition = false;
            }
        }
    }
}
