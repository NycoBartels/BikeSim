using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bikemovement : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float MovZ = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(0,rb.velocity.y,MovZ) * speed;
    }
}
