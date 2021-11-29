using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float movespeed = 500f;
    private Vector3 playerDir;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        MoveBike();
        
    }

    private void MoveBike() {
        // momentum based movement. will need reworking for controller (and eventually VR controller)
        rb.AddForce(new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * movespeed, 0f, Input.GetAxisRaw("Vertical") * Time.deltaTime * movespeed));
    }

    private void Move() {
        // Simple movement stuff. Rewrite to AddForce soon for bike feeling/momentum
        playerDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        Vector3.Normalize(playerDir);
        rb.velocity = new Vector3(playerDir.x * Time.deltaTime * movespeed, 0f, playerDir.z * Time.deltaTime * movespeed);
    }
}
