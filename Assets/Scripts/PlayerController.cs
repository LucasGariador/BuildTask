using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private VehicleController bulldozer;
    [SerializeField] private VehicleController forklift;
    [SerializeField] private VehicleController truck;
    private CameraFollow cameraF;

    void Start()
    {
        cameraF = Camera.main.gameObject.GetComponent<CameraFollow>();
        bulldozer.active = true;
        cameraF.target = bulldozer.transform;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bulldozer.active = true;
            forklift.active = false;
            truck.active = false;

            cameraF.target = bulldozer.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bulldozer.active = false;
            forklift.active = true;
            truck.active = false;

            cameraF.target = forklift.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bulldozer.active = false;
            forklift.active = false;
            truck.active = true;

            cameraF.target = truck.transform;
        }
    }
}
