using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public float CurrentTime { get; private set; }
    
    private void Update()
    {
        UpdateTimer();
    }
    
    private void UpdateTimer()
    {
        CurrentTime += 1 * Time.deltaTime;
    
        int hours = Mathf.FloorToInt(CurrentTime / 3600);
        int minutes = Mathf.FloorToInt((CurrentTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(CurrentTime % 60);
        
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
