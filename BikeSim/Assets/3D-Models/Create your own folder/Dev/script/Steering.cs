using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
float speed = 60;
Vector3 left = new Vector3(0,-40,0);
Vector3 right = new Vector3(0,40,0);
Vector3 idle = new Vector3(0,0,0);
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(left),Time.deltaTime * speed);
        } else                                          
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(right),Time.deltaTime * speed);
        } else {
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(idle),Time.deltaTime * speed);
        }
    }
}
