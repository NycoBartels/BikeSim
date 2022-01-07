using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bikemovement : MonoBehaviour
{
    public Transform Steering;
    public float speed = 0.3f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float MovZ = Input.GetAxisRaw("Vertical");
        if (rb.velocity.z >= 50 || rb.velocity.z <= -20) 
        {

        } else {
            rb.velocity = rb.velocity + new Vector3(0,0,MovZ) * speed;
        }
        if (rb.velocity.z <= 0)
        {
            rb.velocity = rb.velocity + new Vector3(0,0,0.03f);
        } else {
            rb.velocity = rb.velocity - new Vector3(0,0,0.03f);
        }
    }
}
