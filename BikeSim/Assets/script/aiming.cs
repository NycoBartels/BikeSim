using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiming : MonoBehaviour
{

    public float mousesens = 100f;
    public Transform player;
    float Rotatex = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesens * Time.deltaTime;

        Rotatex -= mouseY;
        Rotatex = Mathf.Clamp(Rotatex, -90f, 90f);

        transform.localRotation = Quaternion.Euler(Rotatex, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

    }
}
