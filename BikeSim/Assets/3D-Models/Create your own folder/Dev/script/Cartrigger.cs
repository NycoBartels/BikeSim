using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartrigger : MonoBehaviour
{
    [SerializeField]
    private bool SpeedCar = false, moveRight = false, looping = false, oncoming = false;
    private bool TriggerEnter = false, startedLoop = false;
    private float MoveDirection;
    private float horizontalSpeed;
    [SerializeField] private float timer;
    private Vector3 startPos;

    private void Start() {
        startPos = transform.position;
    }
    private void OnTriggerEnter(Collider Triggered)
    {
        if (Triggered.gameObject.tag == "Player")
        {
            TriggerEnter = true;
            if (moveRight == true) // checks if the car has 'right dir' to change the move direction 
            {
                MoveDirection = 0.04f;
            }   else // if the tag isnt right then it has to be left
            {
                MoveDirection = -0.04f;
            }
            if (oncoming == true) {
                horizontalSpeed = -.04f;
                MoveDirection = 0f;
            }
            if (SpeedCar == true) // bool for what cars we want to go fast
            {
                MoveDirection *= 3;
                horizontalSpeed *= 3;
            }
        }
    }

    private void FixedUpdate()
    {
        MoveCar();
    }
    private void MoveCar()
    {
        if (TriggerEnter == true)
        {
            transform.position = transform.position + new Vector3(MoveDirection, 0f, horizontalSpeed); // simple transform to move car
        }
        if (looping == true && startedLoop == false) {
            Invoke("ResetCarPosition", timer);
            
            startedLoop = true;
        } 
        if (looping != true) {
            Destroy(gameObject, timer); // Destroys the car after 5 secons
        }

    }

    private void ResetCarPosition() {
        transform.position = startPos;
        startedLoop = false;
    }
}
