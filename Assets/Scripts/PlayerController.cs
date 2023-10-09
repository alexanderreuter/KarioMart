using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int playerID;
    private CheckPointManager checkPointManager;
    
    public int PlayerID
    {
        get { return playerID; }
    }
    
    void Awake()
    {
        checkPointManager = GetComponent<CheckPointManager>();
        RaceManager.Instance.RegisterCheckPointManager(checkPointManager);
        checkPointManager.Initialize(playerID);
        Debug.Log("Player " + (playerID + 1) + "spawned with ID " + playerID);
    }
}
