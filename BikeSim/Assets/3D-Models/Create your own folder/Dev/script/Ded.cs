using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine;

public class Ded : MonoBehaviour
{
    private GameObject speed;
    void Start()
    {
        speed = GameObject.FindGameObjectWithTag("Fast");
    }
    private void OnTriggerEnter(Collider Kill)
    {
        if (Kill.gameObject.tag == "Obstacle" || Kill.gameObject.tag == "Cars" || Kill.gameObject.tag == "Box" || Kill.gameObject.tag == "Bike")
        {
            AnalyticsResult analyticsResult = Analytics.CustomEvent("PlayerDied",
                new Dictionary<string, object> {
                    { "Position", Mathf.RoundToInt(transform.position.z / 20f) },
                    { "Cause of Death", Kill.gameObject.tag.ToString() }
                });
            Debug.Log("analyticalResult: " + analyticsResult);
            Destroy(gameObject);
        }
        if (Kill.gameObject.tag == "Fast")
        {
            speed.SetActive(false);
        }
    }
}
