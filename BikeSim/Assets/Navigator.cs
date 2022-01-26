using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("MenuV1");
        }
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Graph");
        }
    }
}
