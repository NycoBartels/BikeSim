using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour
{

    public string escape;
    public string enter;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(escape);
        }
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene(enter);
        }
    }
}
