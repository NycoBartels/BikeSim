using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{

    private Stats stats;
    private void Start() {
        stats = GetComponent<Stats>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "FinishLine") {
            stats.SetPlayerPrefs();
            other.GetComponent<BoxCollider>().enabled = false;
            SceneManager.LoadScene("YouWon");
        }
    }

    
}
