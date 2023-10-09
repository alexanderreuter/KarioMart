using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int checkpointIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            int playerID = other.GetComponent<PlayerController>().PlayerID;
            CheckPointManager checkPointManager = RaceManager.Instance.checkPointManagers[playerID];
            checkPointManager.OnCheckPointPassed(checkpointIndex);
        }
    }
}
