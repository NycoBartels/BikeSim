using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    private Rigidbody rb;
    private CapsuleCollider coll;

    private Vector3 speed;
    [SerializeField] private float accel = 10f;
    [SerializeField] private float breakSpeed = 5f;
    private float dir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        

        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(transform.forward * accel);
        } else if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(-transform.forward * breakSpeed);
        }
        Steer();
        UpdateSteeringWheel();
        /*
        dir = Input.GetAxis("Horizontal");

        Steer();

        if (Input.GetKeyDown(KeyCode.W)) {
            Steer();
            rb.AddForce();
        }
        if (Input.GetKeyDown(KeyCode.U)) {
            rb.velocity = new Vector3(10f, 0f, 0f);
        }*/
    }

    private void Steer() {

        Quaternion oldAngle = coll.transform.rotation;
        Quaternion endingAngle = Quaternion.Euler(new Vector3(0, Input.GetAxis("Horizontal") * 45, 0));
        //Quaternion endingAngle = Quaternion.Euler(new Vector3(oldAngle.eulerAngles.x, oldAngle.eulerAngles.y + Input.GetAxis("Horizontal")/3, oldAngle.eulerAngles.z));

        Quaternion newAngle = Quaternion.RotateTowards(coll.transform.rotation, endingAngle, 50f * Time.deltaTime);

        coll.transform.rotation = endingAngle;

    }
    private void UpdateSteeringWheel() {
        
    }

    IEnumerator RotateBike() {
        float movespeed = 50f;
        Quaternion endingAngle = Quaternion.Euler(new Vector3(0, Input.GetAxis("Horizontal"), 0));

        while (Vector3.Distance(coll.transform.rotation.eulerAngles, endingAngle.eulerAngles) > .01f) 
        {
            coll.transform.rotation = Quaternion.RotateTowards(coll.transform.rotation, endingAngle, movespeed * Time.deltaTime);
            yield return null;
        }
        coll.transform.rotation = endingAngle;
    }
}
