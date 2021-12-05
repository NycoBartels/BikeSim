using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ded : MonoBehaviour
{
    public void OnCollisionStay(Collision Kill)
    {
        Debug.Log("why");
        if (Kill.gameObject.tag == "Obstacle")
        {
            Debug.Log("YES");
            Destroy(gameObject);
        }
    }
}
