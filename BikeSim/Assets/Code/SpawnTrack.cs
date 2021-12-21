using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrack : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private GameObject trackDest;
    private BoxCollider coll;
    [SerializeField]
    private GameObject prefab;

    private void Start() {
        coll = GetComponent<BoxCollider>();
        if (player == null) {
            //make sure player is assigned (due to prefab shenanigans)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            SpawnNewTrack();
        }
    }

    private void SpawnNewTrack() {
        //Spawn new track at "TrackDestination" object
        Instantiate(prefab, trackDest.transform);
    }
}
