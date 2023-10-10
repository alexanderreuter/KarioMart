using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaceManager : MonoBehaviour
{
    public static RaceManager Instance;
    
    public List<CheckpointManager> checkpointManagers = new List<CheckpointManager>();
    private bool isRaceStarting;
    private bool isRaceLive;
    private bool isRaceCompleted;
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

    public void RegisterCheckPointManager(CheckpointManager manager)
    {
        checkpointManagers.Add(manager);
    }
    
    public bool IsRaceLive
    {
        get { return isRaceLive; }
        set { isRaceLive = value; }
    }

    public bool IsRaceStarting
    {
        get { return isRaceStarting; }
        set { isRaceStarting = value; }
    }
    
    public bool IsRaceCompleted
    {
        get { return isRaceCompleted; }
        set { isRaceCompleted = value; }
    }
    
    void Start()
    {
        isRaceLive = false;
        isRaceStarting = false;
        isRaceCompleted = false;
    }
    
    private void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame && !isRaceLive && !isRaceStarting)
        {
            Debug.Log("Enter key pressed, starting race");
            isRaceStarting = true;
        }
    }
}
