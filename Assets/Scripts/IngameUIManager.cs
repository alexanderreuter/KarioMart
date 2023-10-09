using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class IngameUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lapsText;

    private void OnEnable()
    {
        CheckPointManager.OnLapCompleted += UpdateLapsText; 
    }

    private void OnDisable()
    {
        CheckPointManager.OnLapCompleted -= UpdateLapsText; 
    }

    private void UpdateLapsText(int currentLap, int totalLaps)
    {
        lapsText.text = Convert.ToString("Lap " + currentLap + "/" + totalLaps);
    }
}
