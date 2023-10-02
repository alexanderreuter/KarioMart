using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int checkpointIndex;
    //[SerializeField] private bool isFinishLine = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        { 
            //Debug.Log("Checkpoint " + checkpointIndex + " passed!");
            RaceManager.Instance.OnCheckPointPassed(checkpointIndex);
        }
    }
}
