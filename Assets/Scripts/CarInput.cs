using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarInput : MonoBehaviour
{
    CarController carController;

    private void Awake()
    {
        carController = GetComponent<CarController>();
    }
    
    // Read input using Unity's input system
    public void PlayerInput(InputAction.CallbackContext context)
    {
        carController.SetInputVector(context.ReadValue<Vector2>());
    }
}
