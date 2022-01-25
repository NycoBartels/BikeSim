using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    [SerializeField]
    public Rigidbody Firsthalf,Secondhalf;
    private Quaternion FirstTarget,SecondTarget,FirstReturn,SecondReturn;
    private float Speed = 20f;
    public void Start()
    {
        FirstTarget = Quaternion.Euler(-45,0,0);
        SecondTarget = Quaternion.Euler(45,0,0);
        FirstReturn = Firsthalf.rotation;
        SecondReturn = Secondhalf.rotation;
    }
    
    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            float step = Speed * Time.deltaTime;
            Firsthalf.rotation = Quaternion.RotateTowards(FirstReturn,FirstTarget,step);
            
        }
    }
}
