using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    public void GetInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        SteeringAngle = MaxSteerAngle * HorizontalInput;
        Front1W.steerAngle = SteeringAngle;
        Front2W.steerAngle = SteeringAngle;
    }

    private void Accelerate()
    {
        Back1W.motorTorque = VerticalInput * Force;
        Back2W.motorTorque = VerticalInput * Force;
        Front1W.motorTorque = VerticalInput * Force;
        Front2W.motorTorque = VerticalInput * Force;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(Front1W,Front1T);
        //UpdateWheelPose(Front1W,Steering);
    }
    
    private void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 pos = transform.position;
        Quaternion quat = transform.rotation;

        collider.GetWorldPose(out pos, out quat);
        
        transform.rotation = quat;
    } 

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
        if (HorizontalInput >= 0)
        {
            Front1T.position +=  new Vector3(0,HorizontalInput * -2,0);
        }
    }
    private float HorizontalInput;
    private float VerticalInput;
    private float SteeringAngle;
    public WheelCollider Front1W,Front2W;
    public WheelCollider Back1W,Back2W;
    public Transform Front1T,Front2T,Steering;
    public Transform Back1T,Back2T;
    public float MaxSteerAngle = 30;
    public float Force = 50;
}
