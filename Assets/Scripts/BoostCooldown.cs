using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostCooldown : MonoBehaviour
{
    private float boostCooldownTime = 5f; 
    private bool isBoostOnCooldown;
    public Slider boostSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        isBoostOnCooldown = true;
        
        if (boostSlider == null)
        {
            Debug.LogError("Boost Slider not assigned in inspector.");
        }
        
    }
    
    void Update()
    {
        if (isBoostOnCooldown && RaceManager.Instance.IsRaceLive)
        {
            boostCooldownTime -= Time.deltaTime;
            if (boostCooldownTime <= 0f)
            {
                isBoostOnCooldown = false;
                boostCooldownTime = 0f;
            }

            UpdateBoostSlider();
        }
    }
    
    // Getter for isBoostOnCooldown
    public bool IsBoostOnCooldown()
    {
        return isBoostOnCooldown;
    }

    public void StartBoostCooldown()
    {
        isBoostOnCooldown = true;
        
        // Reset the cooldown time when the boost starts 
        boostCooldownTime = 5f;
    }

    private void UpdateBoostSlider()
    {
        if (boostSlider != null)
        {
            float fillValue = Mathf.Clamp01(boostCooldownTime / 5f); // Normalize the value
            boostSlider.value = 1 - fillValue; // Invert the value to match the fill direction
        }
    }
}
