using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Biker;
    public GameObject Spawnpoint;
    void OnTriggerEnter(Collider boop)
    {
        if (boop.gameObject.tag == "Player")
        {
            Instantiate(Biker,Spawnpoint.transform.position,Quaternion.identity);
        }
    }
}
