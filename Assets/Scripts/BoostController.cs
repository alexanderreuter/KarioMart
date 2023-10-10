using UnityEngine;

public class BoostController : MonoBehaviour
{
    private CarController carController;
    private TrailRenderer trailRenderer;
    
    private void Awake()
    {
        carController = GetComponentInParent<CarController>();
        trailRenderer = GetComponent<TrailRenderer>();
        
        // Set the trail renderer to not emit trail on default
        trailRenderer.emitting = false;
    }
    
    private void Update()
    {
        if (carController.IsBoosting())
            trailRenderer.emitting = true;
        else
            trailRenderer.emitting = false;
    }
}
