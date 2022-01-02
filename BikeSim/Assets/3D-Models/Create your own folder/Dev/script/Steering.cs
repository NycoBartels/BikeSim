using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.rotation = Quaternion.Euler(0,-40,0);
        } else
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.rotation = Quaternion.Euler(0,40,0);
        } else {
            this.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}
