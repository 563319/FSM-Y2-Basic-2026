using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(-2, 0, 0);
    }

    
    void Update()
    {
        
    }
}
