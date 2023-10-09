using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class PreRaceUIController : MonoBehaviour
{
    [SerializeField] private GameObject countdownCanvas;
    [SerializeField] private GameObject preRaceCanvas;
    [SerializeField] private TextMeshProUGUI countdownText;
    private bool beenRun; // remove?
    
    void Start()
    {
        preRaceCanvas.SetActive(true);
        countdownCanvas.SetActive(false);
        beenRun = false;
        Debug.Log("Active canvas");
    }
    
    void Update()
    {
        if (RaceManager.Instance.IsRaceStarting && !beenRun && !RaceManager.Instance.IsRaceLive)
        {
            beenRun = true;
            preRaceCanvas.SetActive(false);
            StartCoroutine(StartCountdown());
        }
    }

    private IEnumerator StartCountdown()
    {
        countdownCanvas.SetActive(true);
        
        countdownText.text = "3";
        
        yield return new WaitForSeconds(1);
        countdownText.text = "2";
        
        yield return new WaitForSeconds(1);
        countdownText.text = "1";
        
        yield return new WaitForSeconds(1);
        countdownText.text = "Go!";
        
        RaceManager.Instance.IsRaceLive = true;
        RaceManager.Instance.IsRaceStarting = false;
        
        yield return new WaitForSeconds(1);
        countdownCanvas.SetActive(false);
    }
}
