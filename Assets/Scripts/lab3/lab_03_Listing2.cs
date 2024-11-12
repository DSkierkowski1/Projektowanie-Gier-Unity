using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab_03_Listing2 : MonoBehaviour
{
    public float force = 5.0f;
    
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
