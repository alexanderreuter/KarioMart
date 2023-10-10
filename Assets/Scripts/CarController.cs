using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    [SerializeField] private float accelerationSpeed = 15.0f;
    [SerializeField] private float turnSpeed = 3.8f;
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float driftFactor = 0.95f; 
    [SerializeField] private float boostSpeed = 30.0f;
    private float accelerationInput;
    private float turnInput;
    private float rotationAngle;
    private float dotOfVelocityAndUp;
    private float minSpeedBeforeTurn;
    private float lateralVelocity;
    private bool isBoosting;
    private Rigidbody2D rb;
    private BoostCooldown boostCooldown;
    
    public bool IsBoosting()
    {
        return isBoosting;
    }
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boostCooldown = GetComponent<BoostCooldown>();
    }
    
    private void Start()
    {
        isBoosting = false;
        rotationAngle = transform.rotation.eulerAngles.z;
    }
    
    private void FixedUpdate()
    {
        if (RaceManager.Instance.IsRaceLive)
        {
            AccelerationForce();
            ReduceOrthogonalVelocity();
            TurnForce();
        }
    }
    
    public void PlayerInput(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>(); 
        accelerationInput = inputVector.y;
        turnInput = inputVector.x;
    }
    
    public void Boost()
    {
        if (!boostCooldown.IsBoostOnCooldown())
        {
            Debug.Log("Boosting started");
            isBoosting = true;
            boostCooldown.StartBoostCooldown();
            StartCoroutine(StartBoost());
        }
    }
    
    IEnumerator StartBoost()
    {
        yield return new WaitForSeconds(0.5f); 
        Debug.Log("Boosting over");
        isBoosting = false;
    }
    
    private void AccelerationForce()
    {
        // Forward force in relation to velocity direction
        dotOfVelocityAndUp = Vector2.Dot(rb.velocity, transform.up);

        // Add drag when there is no acceleration input
        if (accelerationInput == 0)
            rb.drag = Mathf.Lerp(rb.drag, 3.0f, Time.deltaTime * 3);
        else
            rb.drag = 0.0f;
        
        if (!isBoosting)
        {
            // Add so the car can't go faster than the max speed in the forward direction 
            if (dotOfVelocityAndUp > maxSpeed && accelerationInput > 0)
                return;
            
            // Add so the car can't go faster than the max speed / 2 in the backwards direction 
            if (dotOfVelocityAndUp < -maxSpeed * 0.5f && accelerationInput < 0)
                return;
        
            // Add so we can't go faster than max speed in any direction when accelerating
            if (rb.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
                return;
            
            // Add acceleration
            Vector2 accelerationForce = transform.up * (accelerationInput * accelerationSpeed);
            rb.AddForce(accelerationForce, ForceMode2D.Force);
        }
        else
        {
            // Add acceleration with boost
            Vector2 accelerationForce = transform.up * (accelerationInput * accelerationSpeed * boostSpeed);
            rb.AddForce(accelerationForce, ForceMode2D.Force);
        }
    }
    
    private void TurnForce()
    {
        // Add a minimum speed before allowing to turn
        minSpeedBeforeTurn = (rb.velocity.magnitude / 6);
        minSpeedBeforeTurn = Mathf.Clamp01(minSpeedBeforeTurn);
        
        // Change the rotation based on the turn input
        rotationAngle -= turnInput * turnSpeed * minSpeedBeforeTurn;
        rb.MoveRotation(rotationAngle);
    }
    
    // Reduce the side velocity of the car. This is to prevent the car from drifting too much sideways
    private void ReduceOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 sideVelocity = transform.right * Vector2.Dot(rb.velocity, transform.right);
        rb.velocity = forwardVelocity + sideVelocity * driftFactor;
    }

    public bool IsTireScreeching()
    {
        lateralVelocity = Vector2.Dot(rb.velocity, transform.right);
        
        // If the car is moving forward and the car is braking, activate skidmarks
        if (accelerationInput < 0 && dotOfVelocityAndUp > 0)
            return true;
        
        // If the car is drifting, activate skidmarks
        if (Mathf.Abs(lateralVelocity) > 4f)
            return true;

        return false;   
    }
}
