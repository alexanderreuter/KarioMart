using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    [SerializeField] private float acceleration = 30.0f;
    [SerializeField] private float turnSpeed = 3.5f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float sideDrift = 0.95f;
    private float accelerationInput;
    private float turnInput;
    private float rotationAngle;
    private float velocityVsUp;
    private float minSpeedBeforeTurn;
    Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //rb.transform.Rotate(0, 0, 90);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        AccelerationForce();
        KillOrthogonalVelocity();
        TurnForce();
    }

    private void AccelerationForce()
    {
        velocityVsUp = Vector2.Dot(rb.velocity, transform.up);
        
        if (velocityVsUp > maxSpeed && accelerationInput > 0)
            return;

        if (velocityVsUp < -maxSpeed * 0.5f && accelerationInput < 0)
            return;
        
        if (rb.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
            return;
        
        if (accelerationInput == 0)
            rb.drag = Mathf.Lerp(rb.drag, 3.0f, Time.deltaTime * 3);
        else
            rb.drag = 0.0f;
        
        Vector2 accelerationForce = transform.up * (accelerationInput * acceleration);
        rb.AddForce(accelerationForce, ForceMode2D.Force);
    }
    
    private void TurnForce()
    {
        minSpeedBeforeTurn = (rb.velocity.magnitude / 8);
        minSpeedBeforeTurn = Mathf.Clamp01(minSpeedBeforeTurn);
        
        rotationAngle -= turnInput * turnSpeed * minSpeedBeforeTurn;
        rb.MoveRotation(rotationAngle);
    }
    
    public void SetInputVector(Vector2 inputVector)
    {
        accelerationInput = inputVector.y;
        turnInput = inputVector.x;
    }
    
    // Adjusts the velocity of the car to be in the direction of the car's forward vector.
    private void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb.velocity, transform.right);
        rb.velocity = forwardVelocity + rightVelocity * sideDrift;
    }
}
