using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartrigger : MonoBehaviour
{
    bool Enter = false;
    float KillCar = 99999999f;
    float left = -0.5f;
    float right = 0.5f;
    float move;
    public void OnTriggerEnter(Collider boom)
    {
        if (boom.gameObject.tag == "Player")
        {
            if (transform.localScale.x > 0.1)
            {
                move = left;
            }
            else
            {
                move = right;
            }

            Enter = true;

            KillCar = Time.time + 5f;
        }
    }

    void FixedUpdate()
    {
        if (Enter == true)
        {
            transform.position = transform.position + new Vector3(move, 0f, 0f);
        }
        if (KillCar < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
