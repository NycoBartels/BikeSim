using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    private float SteeringAngle;
    public WheelCollider Front1W, Front2W;
    public WheelCollider Back1W, Back2W;
    public Transform Front1T, Front2T;
    public Transform Back1T, Back2T;
    Vector3 m_EulerAngleVelocity;
    public float MaxSteerAngle = 30;
    public float Force = 20, tempForce;
    [SerializeField] private float accel;
    public Transform SteeringWheel;
    public Rigidbody rb;

    private void Start()
    {
        tempForce = Force * 4;
    }
    public void GetInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        // SteeringAngle = MaxSteerAngle * ((SteeringWheel.rotation.z * 100) / 20);
        SteeringAngle = MaxSteerAngle * HorizontalInput;
        Front1W.steerAngle = SteeringAngle;
        Front2W.steerAngle = SteeringAngle;
        // SteeringWheel.rotation = Quaternion.Euler(81.84f,0,SteeringAngle);
    }

    private void Accelerate()
    {
        if (VerticalInput > 0)
        {
            
            Back1W.motorTorque = VerticalInput * Force;
            Back2W.motorTorque = VerticalInput * Force;
            Front1W.motorTorque = VerticalInput * Force;
            Front2W.motorTorque = VerticalInput * Force; 
        } else {
            Back1W.motorTorque = VerticalInput * tempForce;
            Back2W.motorTorque = VerticalInput * tempForce;
            Front1W.motorTorque = VerticalInput * tempForce;
            Front2W.motorTorque = VerticalInput * tempForce;
        }
        Vector3 vel = rb.velocity;
        if (vel.magnitude > 100) 
        {
            Force = -accel;
        } else {
            Force = accel;
        }
        
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(Front1W,Front1T);
        
    }
    
    private void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 pos = transform.position;
        Quaternion quat = transform.rotation;

        collider.GetWorldPose(out pos, out quat);
        transform.rotation = quat;
    } 
    private void FallCheck()
    {
       if ((this.transform.eulerAngles.z > 60 && this.transform.eulerAngles.z < 250 )||(this.transform.eulerAngles.z < -60 && this.transform.eulerAngles.z > -250 )) 
       {
           Time.timeScale = 0;
       }
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
        FallCheck();
    }
    
}
