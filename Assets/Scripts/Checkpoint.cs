using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int checkpointIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            int playerID = other.GetComponent<PlayerController>().PlayerID;
            CheckpointManager checkpointManager = RaceManager.Instance.checkpointManagers[playerID];
            checkpointManager.OnCheckPointPassed(checkpointIndex);
        }
    }
}
