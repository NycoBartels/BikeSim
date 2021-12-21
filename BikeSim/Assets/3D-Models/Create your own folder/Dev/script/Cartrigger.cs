using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartrigger : MonoBehaviour
{
    public GameObject speed;
    bool Enter = false;
    float KillCar = 99999999f;
    float left = -0.7f;
    float right = 0.7f;
    float move;
    void Start()
    {
        speed = GameObject.FindGameObjectWithTag("Fast");
    }
    public void OnTriggerEnter(Collider boom)
    {
        if (boom.gameObject.tag == "Fast")
        {
            speed.SetActive(false);
        }
        if (boom.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "right")
            {
                move = right;
            }
            else
            {
                move = left;
            }
            if (speed.activeSelf)
            {
                move *= 3;
                speed.SetActive(false);
            } else 
            {
                speed.SetActive(true);
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
