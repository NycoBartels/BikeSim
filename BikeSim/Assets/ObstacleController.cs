using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    private Rigidbody rb;
    [SerializeField]
    private float margin = 20f;
    private bool inRange = false;
    private bool moving = false;

    [SerializeField]
    private float speed = 75f;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        if (player == null) {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
    }

    private void Update() {
        //Check if player is somewhat close
        if (player.transform.position.z >= transform.position.z - margin) {
            inRange = true;
        }
        if (inRange && !moving) {
            
            //Find out which direction obstacle should move to
            if (player.transform.position.x > transform.position.x) {

            }
            //Move to middle of the lane
            rb.velocity = new Vector3(CompareToPlayerPos() * speed * Time.deltaTime, 0f, 0f);

        }
    }

    private float CompareToPlayerPos() {
        var playerPos = player.transform.position.x;
        var obstaclePos = transform.position.x;
        if (Mathf.Sign(playerPos - obstaclePos) > 0) {
            return 1f;
        } else {
            return -1f;
        }
        //This only checks if obstacle is to the left or right of the player.
        // Returns value needed for directional movement of obstacle on the X-Axis
    }
}
