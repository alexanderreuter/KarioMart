using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private int playerIndex;
    private int sceneIndex;
    [SerializeField] List<GameObject> players = new List<GameObject>();
    PlayerInputManager playerInputManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SpawnPlayer();
    }
    
    public void SpawnPlayer()
    {
        playerInputManager.playerPrefab = players[playerIndex];
        SetPlayerSpawnPosition(sceneIndex, playerIndex);
        if (players.Count - 1 > playerIndex)
            playerIndex++;
    }

    private void SetPlayerSpawnPosition(int sceneIndex, int playerIndex)
    {
        if (sceneIndex == 1)
        {
            if (playerIndex == 0)
            {
                playerInputManager.playerPrefab.transform.position = new Vector3(0.5f,8, 0);
            }
            else if (playerIndex == 1)
            {
                playerInputManager.playerPrefab.transform.position = new Vector3(0.5f,6.5f, 0);
            }
            
            playerInputManager.playerPrefab.transform.eulerAngles = new Vector3(0,0,90);
        }

        if (sceneIndex == 2)
        {
            if (playerIndex == 0)
            {
                playerInputManager.playerPrefab.transform.position = new Vector3(-12f, 5.2f, 0);
            }
            else if (playerIndex == 1)
            {
                playerInputManager.playerPrefab.transform.position = new Vector3(-12f, 3.7f, 0);
            }
            
            playerInputManager.playerPrefab.transform.eulerAngles = new Vector3(0, 0, 270);
        }
        
        if (sceneIndex == 3)
        {
            if (playerIndex == 0)
            {
                playerInputManager.playerPrefab.transform.position = new Vector3(-3f, 9f, 0);
            }
            else if (playerIndex == 1)
            {
                playerInputManager.playerPrefab.transform.position = new Vector3(-3f, 7.5f, 0);
            }
                
            playerInputManager.playerPrefab.transform.eulerAngles = new Vector3(0, 0, 270);
        }
    }
}
