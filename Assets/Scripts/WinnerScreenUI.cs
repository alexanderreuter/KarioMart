using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinnerScreenUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private GameObject winnerScreenCanvas;
    
    private void OnEnable()
    {
        CheckpointManager.OnRaceCompleted += HandleRaceCompleted;
    }

    private void OnDisable()
    {
        CheckpointManager.OnRaceCompleted -= HandleRaceCompleted;
    }

    private void Start()
    {
        winnerScreenCanvas.SetActive(false);
    }

    private void HandleRaceCompleted(int playerID)
    {
        winnerScreenCanvas.SetActive(true);
        winnerText.text = "Player " + (playerID + 1) + " wins!";
    }
    
    public void LevelOne()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LevelTwo()
    {
        SceneManager.LoadScene(2);
    }
    
    public void LevelThree()
    {
        SceneManager.LoadScene(3);
    }
    
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
