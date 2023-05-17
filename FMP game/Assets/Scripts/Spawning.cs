using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Spawning : MonoBehaviour
{
    public GameObject southeast, east, northeast, north, northwest, west, southwest;
    double roundstart;
    double current;
    public GameObject enemy;
    bool wave1 = false;
    int wave1count = 0;
    void Start()
    {
        roundstart = Time.time;
    }

    void Update()
    {
        current = Time.time + roundstart;
        if(current > roundstart + 3 && wave1count == 0)
        {
            wave1 = true;
            wave1count += 1;
        }
        if (wave1)
        {
            Instantiate(enemy, east.transform.position, Quaternion.identity);
            Instantiate(enemy, southeast.transform.position, Quaternion.identity);
            Instantiate(enemy, northeast.transform.position, Quaternion.identity);
            Instantiate(enemy, north.transform.position, Quaternion.identity);
            Instantiate(enemy, northwest.transform.position, Quaternion.identity);
            Instantiate(enemy, west.transform.position, Quaternion.identity);
            Instantiate(enemy, southwest.transform.position, Quaternion.identity);
            wave1 = false;
        }
    }
}
