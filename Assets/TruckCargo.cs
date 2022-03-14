using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckCargo : MonoBehaviour
{
    [SerializeField] private TextMesh text;

    [HideInInspector] public int cargoAmount = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("ReadyTrashBox") && cargoAmount < 5)
        {
            cargoAmount++;
            text.text = cargoAmount + "/5";
            Destroy(collision.gameObject);
        }
    }
}
