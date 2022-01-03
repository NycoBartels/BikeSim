using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashScreen : MonoBehaviour
{

    public GameObject m_GotHitScreen;   

    //DEPRECATED code for collision instead of invisibile trigger
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Hurtbox") {
            gotHurt();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Hurtbox") {
            gotHurt();
        }
    }


    private void gotHurt() {
        //Set hurt image transparency to 80%
        var color = m_GotHitScreen.GetComponent<Image>().color;
        color.a = .8f;

        m_GotHitScreen.GetComponent<Image>().color = color;
    }

    private void Update() {
        // Reduce hurt image transparency every frame, if its still on screen
        if (m_GotHitScreen != null) {
            if (m_GotHitScreen.GetComponent<Image>().color.a > 0) {
                var color = m_GotHitScreen.GetComponent<Image>().color;
                color.a -= Time.deltaTime;
                m_GotHitScreen.GetComponent<Image>().color = color;
            }
        }
    }
}
