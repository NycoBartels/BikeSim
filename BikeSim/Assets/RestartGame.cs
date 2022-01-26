using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update
    private Stats stats;
    private void Start() {
        if (stats != null) {
            stats = GetComponent<Stats>();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if(stats != null) {
                stats.ResetStats();
            }
            SceneManager.LoadScene("Hidde1");
        }
    }
}
