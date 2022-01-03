using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ded : MonoBehaviour
{
    public GameObject speed;
    public GameObject lvlloc2;
    public GameObject player;
    void Start()
    {
        speed = GameObject.FindGameObjectWithTag("Fast");
    }
    public void OnTriggerEnter(Collider Kill)
    {
        if (Kill.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
        if (Kill.gameObject.tag == "Cars")
        {
            Destroy(gameObject);
        }
        if (Kill.gameObject.tag == "Box")
        {
            Destroy(gameObject);
        }
        if (Kill.gameObject.tag == "Bike")
        {
            Destroy(gameObject);
        }
        if (Kill.gameObject.tag == "Fast")
        {
            speed.SetActive(false);
        }
        if (Kill.gameObject.tag == "2ndlvl")
        {
            Destroy(gameObject);
            Instantiate(player,lvlloc2.transform.position,Quaternion.identity);
        }
    }
}
