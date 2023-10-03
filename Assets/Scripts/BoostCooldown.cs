using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostCooldown : MonoBehaviour
{
    public bool isBoostOnCooldown { get; private set; }
    private float startBoostTime;
    private float currentTime;
    
    // Start is called before the first frame update
    void Start()
    {
        isBoostOnCooldown = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
