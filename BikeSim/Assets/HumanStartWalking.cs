using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStartWalking : MonoBehaviour
{

    [SerializeField] private float movespeed = 10f;
    [SerializeField] private CharacterController player;
    private Rigidbody rb;
    private bool isWalking = false;

    void Start()
    {
        player = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (isWalking) {
            Walk();
        }
    }

    private void Walk() {
        rb.velocity = new Vector3(-movespeed, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            isWalking = true;
        }
    }

}
