using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTrigger : MonoBehaviour
{
    [HideInInspector] public bool charged = false;

    [HideInInspector] public GameObject target;


    private void Start()
    {
        target.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!charged && other.transform.CompareTag("TrashBox"))
        {
            charged = true;
            Load();
            Destroy(other.gameObject);
        }
    }

    public void Load()
    {
        target.SetActive(true);
    }

    public void Unload()
    {
        target.SetActive(false);
        charged = false;
    }
}
