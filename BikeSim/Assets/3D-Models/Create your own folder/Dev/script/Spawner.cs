using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject Bike;
    public GameObject Spawnbike;

    public void OnTriggerEnter(Collider boop)
    {
        if (boop.gameObject.tag == "Player")
        {
            Instantiate(Bike,Spawnbike.transform.position,Quaternion.identity);
        }
    }
}
