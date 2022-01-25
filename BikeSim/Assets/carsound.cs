using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carsound : MonoBehaviour
{   
    
    public AudioSource Carbrr;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "SoundCar") {
            Carbrr.Play();
        }
    }
}