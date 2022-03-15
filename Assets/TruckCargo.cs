using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckCargo : MonoBehaviour
{
    [SerializeField] private TextMesh text;

    [HideInInspector] public int cargoAmount = 0;
    private AudioSource audioSource;
    [SerializeField] private AudioClip crash;
    [SerializeField] private AudioClip bag;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("ReadyTrashBox") && cargoAmount < 5)
        {
            cargoAmount++;
            text.text = cargoAmount + "/5";
            Destroy(other.gameObject);
            audioSource.clip= bag;
            audioSource.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.clip = crash;
        audioSource.Play();
    }
}
