using System;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static event Action<int, int> OnLapCompleted;
    
    // Delegate is used since two Action events with different parameter size can't be declared
    public delegate void RaceCompletedEventHandler(int playerID); 
    public static event RaceCompletedEventHandler OnRaceCompleted;
    
    [SerializeField] private int totalLaps = 3;
    private int currentCheckpoint = -1; // Initialized to -1 since the player start behind the finish line
    private int currentLap = 1;
    private int numberOfCheckpoints;
    private int playerID;
    
    public void Initialize(int playerID)
    {
        this.playerID = playerID;
    }
    
    private void Start()
    {
        // Checkpoints are stored as children under the RaceManager in each level 
        numberOfCheckpoints = RaceManager.Instance.transform.childCount;
        
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
            Debug.Log("Player " + (playerID + 1) + ", Race completed!");
            OnRaceCompleted?.Invoke(playerID);
            RaceManager.Instance.IsRaceLive = false;
            RaceManager.Instance.IsRaceCompleted = true;
        }
    }    
}
