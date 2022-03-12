using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclePoint : MonoBehaviour
{
    private int trashAmount = 0;
    private int trashBoxesCreated = 0;

    [SerializeField] private TrashBoxesGenerator trashGenerator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Trash"))
        {
            trashAmount++;
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if(trashAmount >= 10*(trashBoxesCreated+1))
        {
            Debug.Log("CreatedBox");
            trashBoxesCreated++;
            trashGenerator.NewBox();
        }
    }
}
