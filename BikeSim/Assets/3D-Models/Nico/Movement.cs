using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private BikeController controller;
    private Vector3 speed;
    [SerializeField] private float accel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        //speed = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0f, Input.GetAxisRaw("Vertical") * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W)) {
            
        }

    }
}
