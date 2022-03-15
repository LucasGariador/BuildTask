using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private VehicleController truck;
    private CameraFollow cameraF;

    public void StartGame()
    {
        cameraF = Camera.main.gameObject.GetComponent<CameraFollow>();
        truck.active = true;
        cameraF.target = truck.transform;
    }

}
