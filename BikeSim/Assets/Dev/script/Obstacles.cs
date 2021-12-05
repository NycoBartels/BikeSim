using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject[] Cars = new GameObject[2];
    public GameObject[] Locs = new GameObject[6];
    public int carpick;
    public int locpick;
    public float loc;
    Vector3 newloc;
    void Start() 
    {
        newloc = new Vector3(0,0,101.88f);
        for (int i = 0;i < 3; i++)
        {
            loc = Random.Range(0f,2f);
            if (loc < 1) 
            {
                if (i == 0)
                {
                    locpick = 0;
                } else if (i == 1)
                {
                    locpick = 2;
                } else 
                {
                    locpick = 4;
                }
                carpick = 0;
            }  else 
            {
                if (i == 0)
                {
                    locpick = 1;
                } else if (i == 1)
                {
                    locpick = 3;
                } else 
                {
                    locpick = 5;
                }
                carpick = 1;
            }
            Instantiate(Cars[carpick],Locs[locpick].transform);
        }
    }
}
