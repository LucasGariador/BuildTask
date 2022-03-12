using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBoxesGenerator : MonoBehaviour
{
    [SerializeField] private GameObject Box;
    public void NewBox()
    {
        Instantiate(Box, new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z), Quaternion.identity);
    }
}
