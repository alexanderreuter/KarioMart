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
    
    public void PlayerInput(InputAction.CallbackContext context)
    {
        Debug.Log("PlayerInput called");
        carController.SetInputVector(context.ReadValue<Vector2>());
    }
}
