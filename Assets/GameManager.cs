using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TruckController truckController;
    [SerializeField] private Gizmo check1;
    [SerializeField] private Gizmo check2;
    [SerializeField] private Gizmo check3;
    [SerializeField] private Gizmo check4;
    [SerializeField] private DirectionCheck directionCheck;

    private void Update()
    {
        if(check1.isIn && check2.isIn && check3.isIn && check4.isIn && directionCheck.rightPosition)
        {
            Debug.Log("Win!!");
            truckController.active = false;
            truckController.Stop();
        }
    }
}
