using System;
using UnityEngine;
using TMPro;

public class IngameUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lapsText;

    private void OnEnable()
    {
        CheckpointManager.OnLapCompleted += UpdateLapsText; 
    }

    private void OnDisable()
    {
        CheckpointManager.OnLapCompleted -= UpdateLapsText; 
    }

    private void UpdateLapsText(int currentLap, int totalLaps)
    {
        lapsText.text = Convert.ToString("Lap " + currentLap + "/" + totalLaps);
    }
}
