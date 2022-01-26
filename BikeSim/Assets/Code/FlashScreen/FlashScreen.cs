using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashScreen : MonoBehaviour
{
    public Stats stats;
    public GameObject m_GotHitScreen;

    private void Start() {
        stats = GetComponent<Stats>();
    }
    //DEPRECATED code for collision instead of invisibile trigger
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Hurtbox") {
            gotHurt();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Hurtbox") {
            gotHurt();
            other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            switch (other.gameObject.name.ToString()) {
                case "FirstCrossingCar":
                    stats.firstCrossingHit();
                    break;
                case "IncomingCar":
                    stats.IncomingCarHit();
                    break;
                case "SecondCrossingCar":
                    stats.SecondCrossingCarHits();
                    break;
                case "ThirdCrossingCar":
                    stats.ThirdCrossingCarHits();
                    break;
                case "ForthCrossingCar":
                    stats.ForthCrossingCarHit();
                    break;
                case "ParkingCar":
                    stats.ParkingCarHit();
                    break;
                case "Human":
                    stats.HumanHit();
                    break;
                default:
                    Debug.Log("Error: no Tag set for Object hit!");
                    break;
            }
        }
    }


    public void gotHurt() {
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
