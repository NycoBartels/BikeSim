using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartrigger : MonoBehaviour
{
    [SerializeField]
    private bool DestroyCar = false, TriggerEnter = false, SpeedCar = false;
    private float MoveDirection;
    private void OnTriggerEnter(Collider Triggered)
    {
        if (Triggered.gameObject.tag == "Player")
        {
            TriggerEnter = true;
            DestroyCar = true;
            if (this.gameObject.tag == "right") // checks if the car has the 'right' tag to change the move direction 
            {
                MoveDirection = 0.04f;
            }   else // if the tag isnt right then it has to be left
            {
                MoveDirection = -0.04f;
            }
            if (SpeedCar == true) // bool for what cars we want to go fast
            {
                MoveDirection *= 3;
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
            transform.position = transform.position + new Vector3(MoveDirection, 0f, 0f); // simple transform to move car
        }
        if (DestroyCar == true)
        {
            Destroy(gameObject,5); // Destroys the car after 5 secons
        }
    }
}
