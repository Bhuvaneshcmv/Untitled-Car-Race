using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTest : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float speed;//=10000;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Rotate()
    {
        
        rb.AddTorque(Vector3.forward * speed *Time.deltaTime);
        Debug.Log("Rotating"+ rb.angularVelocity);
        //rb.angularVelocity = Vector3.forward * Time.deltaTime; 
    }
}
