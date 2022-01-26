using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FirstLine : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "Test text pls work";
    }
}
