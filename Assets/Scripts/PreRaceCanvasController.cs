using System.Collections;
using UnityEngine;
using TMPro;

public class PreRaceUIController : MonoBehaviour
{
    [SerializeField] private GameObject countdownCanvas;
    [SerializeField] private GameObject preRaceCanvas;
    [SerializeField] private TextMeshProUGUI countdownText;
    private bool countdownBeenRunned;
    
    void Start()
    {
        preRaceCanvas.SetActive(true);
        countdownCanvas.SetActive(false);
        countdownBeenRunned = false;
        Debug.Log("Active canvas");
    }
    
    void Update()
    {
        if (RaceManager.Instance.IsRaceStarting && !countdownBeenRunned && !RaceManager.Instance.IsRaceLive)
        {
            preRaceCanvas.SetActive(false);
            StartCoroutine(StartCountdown());
            countdownBeenRunned = true;
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
