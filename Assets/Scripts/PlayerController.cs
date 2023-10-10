using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int playerID;
    private CheckpointManager checkpointManager;
    
    public int PlayerID
    {
        get { return playerID; }
    }
    
    void Awake()
    {
        checkpointManager = GetComponent<CheckpointManager>();
        RaceManager.Instance.RegisterCheckPointManager(checkpointManager);
        checkpointManager.Initialize(playerID);
        Debug.Log("Player " + (playerID + 1) + "spawned with ID " + playerID);
    }
}
