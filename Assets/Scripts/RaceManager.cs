using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RaceManager : MonoBehaviour
{
    public static RaceManager Instance;
    
    [SerializeField] private GameObject checkpoints;
    [SerializeField] private TextMeshProUGUI lapsText;
    [SerializeField] private int totalLaps = 3;
    private int currentCheckpoint = -1;
    private int currentLap = 1;
    private int numberOfCheckpoints;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        lapsText.text = Convert.ToString("Lap " + currentLap + "/" + totalLaps);
        numberOfCheckpoints = checkpoints.transform.childCount;
    }

    public void OnCheckPointPassed(int checkpointIndex)
    {
        if (checkpointIndex == currentCheckpoint + 1)
        {
            currentCheckpoint = checkpointIndex;
            Debug.Log("Checkpoint " + checkpointIndex + " passed!");
        }
        
        if (currentCheckpoint == numberOfCheckpoints - 1)
        {
            currentCheckpoint = -1;
            Debug.Log("Lap " + currentLap + " completed!");
            currentLap++;
            
            if (currentLap <= totalLaps)
                lapsText.text = Convert.ToString("Lap " + currentLap + "/" + totalLaps);
        }

        if (currentLap > totalLaps)
        {
            Debug.Log("Race completed!");
        }
    }    
}
