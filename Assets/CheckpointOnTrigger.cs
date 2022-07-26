using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointOnTrigger : MonoBehaviour
{
    public bool CheckpointReached;

    private void Awake()
    {
        CheckpointReached = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointReached = true;
        }
    }
}
