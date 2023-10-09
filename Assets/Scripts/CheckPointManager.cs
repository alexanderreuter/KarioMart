using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPointManager : MonoBehaviour
{
    public static event Action<int, int> OnLapCompleted;
    public delegate void RaceCompletedEventHandler(int playerID);
    public static event RaceCompletedEventHandler OnRaceCompleted;
    
    [SerializeField] private int totalLaps = 3;
    private int currentCheckpoint = -1;
    private int currentLap = 1;
    private int numberOfCheckpoints;
    private int playerID;
    
    public void Initialize(int playerID)
    {
        this.playerID = playerID;
        numberOfCheckpoints = RaceManager.Instance.transform.childCount;
    }
    
    private void Start()
    {
        // Initialize UI
        OnLapCompleted?.Invoke(currentLap, totalLaps);
    }
    
    public void OnCheckPointPassed(int checkpointIndex)
    {
        if (checkpointIndex == currentCheckpoint + 1)
        {
            currentCheckpoint = checkpointIndex;
            Debug.Log("Player " + (playerID + 1) + " Checkpoint " + checkpointIndex + " passed!");
        }
        
        if (currentCheckpoint == numberOfCheckpoints - 1)
        {
            currentCheckpoint = -1;
            Debug.Log("Player " + (playerID + 1) + " Lap " + currentLap + " completed!");
            currentLap++;
            
            if (currentLap <= totalLaps)
                OnLapCompleted?.Invoke(currentLap, totalLaps);
        }

        if (currentLap > totalLaps)
        {
            Debug.Log("Player " + (playerID + 1) + "Race completed!");
            OnRaceCompleted?.Invoke(playerID);
            RaceManager.Instance.IsRaceLive = false;
            RaceManager.Instance.IsRaceCompleted = true;
        }
    }    
}
