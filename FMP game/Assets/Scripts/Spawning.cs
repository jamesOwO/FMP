using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements;

public class Spawning : MonoBehaviour
{
    int numofenemies;
    List<GameObject> listOfOpponents = new List<GameObject>();

    public GameObject southeast, east, northeast, north, northwest, west, southwest;
    public Playercontroller Playercontroller;

    double roundstart, round2start = 0, round3start = 0, nextwave;
    double current;
    public GameObject enemy;
    bool wave1 = false, wave2 = false, wave3 = false, subwave1, subwave2, subwave3, subwave4, subwave5, subwave6;
    int wavecount = 0;
    int daf;

    void Start()
    {
        roundstart = Time.time;
    }

    void Update()
    {
        Debug.Log(Playercontroller.enemieskilled);
        current = Time.time + roundstart;

        if (Input.GetKeyDown(KeyCode.Q) && nextwave < current)
            nextwave = current + 5;
            wavecount += 1;

        if (wavecount == 1 && wave1 == false)
        {
            round1();
        }

        if (Playercontroller.enemieskilled == 7)
        {
            round2();
        }
        if (Playercontroller.enemieskilled == 17)
        {
            round3();
        }



    }
    void round1()
    {
        Debug.Log("round 1 begin");

        Instantiate(enemy, east.transform.position, Quaternion.identity);
        Instantiate(enemy, southeast.transform.position, Quaternion.identity);
        Instantiate(enemy, northeast.transform.position, Quaternion.identity);
        Instantiate(enemy, north.transform.position, Quaternion.identity);
        Instantiate(enemy, northwest.transform.position, Quaternion.identity);
        Instantiate(enemy, west.transform.position, Quaternion.identity);
        Instantiate(enemy, southwest.transform.position, Quaternion.identity);
        wave1 = true;
    }
    void round2()
    {
        Debug.Log("round 2 begin");
        if (round2start == 0)
        {
            subwave1 = false; subwave2 = false; subwave3 = false; 
            round2start = current;
        }
        if (round2start + 3 < current && subwave1 == false)
        {
            Instantiate(enemy, north.transform.position, Quaternion.identity);
            Instantiate(enemy, east.transform.position, Quaternion.identity);
            Instantiate(enemy, west.transform.position, Quaternion.identity);
            subwave1 = true;
        }
        if (round2start + 6 < current && subwave2 == false)
        {
            Instantiate(enemy, southwest.transform.position, Quaternion.identity);
            Instantiate(enemy, southeast.transform.position, Quaternion.identity);
            Instantiate(enemy, northeast.transform.position, Quaternion.identity);
            Instantiate(enemy, northwest.transform.position, Quaternion.identity);
            subwave2 = true;
        }
        if (round2start + 9 < current && subwave3 == false)
        {
            Instantiate(enemy, north.transform.position, Quaternion.identity);
            Instantiate(enemy, east.transform.position, Quaternion.identity);
            Instantiate(enemy, west.transform.position, Quaternion.identity);
            subwave3 = true;
            wave2 = true;
        }
    }
    void round3()
    {
        Debug.Log("round 3 begin");
        if (round3start == 0)
        {
            subwave1 = false; subwave2 = false; subwave3 = false; subwave4 = false; subwave5 = false; subwave6 = false;
            round3start = current;
        }
        if (round3start + 2 < current && subwave1 == false)
        {
            Instantiate(enemy, north.transform.position, Quaternion.identity);
            Instantiate(enemy, northeast.transform.position, Quaternion.identity);
            Instantiate(enemy, northwest.transform.position, Quaternion.identity);
            subwave1 = true;
        }
        if (round3start + 4 < current && subwave2 == false)
        {
            Instantiate(enemy, north.transform.position, Quaternion.identity);
            Instantiate(enemy, northeast.transform.position, Quaternion.identity);
            Instantiate(enemy, northwest.transform.position, Quaternion.identity);
            subwave2 = true;
        }
        if (round3start + 6 < current && subwave3 == false)
        {
            Instantiate(enemy, east.transform.position, Quaternion.identity);
            Instantiate(enemy, west.transform.position, Quaternion.identity);
            Instantiate(enemy, southwest.transform.position, Quaternion.identity);
            Instantiate(enemy, southeast.transform.position, Quaternion.identity);
            subwave3 = true;
            wave2 = true;
        }
        if (round3start + 7 < current && subwave4 == false)
        {
            Instantiate(enemy, north.transform.position, Quaternion.identity);
            Instantiate(enemy, northeast.transform.position, Quaternion.identity);
            Instantiate(enemy, northwest.transform.position, Quaternion.identity);
            subwave4 = true;
        }
        if (round3start + 11 < current && subwave5 == false)
        {
            Instantiate(enemy, east.transform.position, Quaternion.identity);
            Instantiate(enemy, southeast.transform.position, Quaternion.identity);
            Instantiate(enemy, northeast.transform.position, Quaternion.identity);
            Instantiate(enemy, north.transform.position, Quaternion.identity);
            Instantiate(enemy, northwest.transform.position, Quaternion.identity);
            Instantiate(enemy, west.transform.position, Quaternion.identity);
            Instantiate(enemy, southwest.transform.position, Quaternion.identity);
            subwave5 = true;
        }
        if (round3start + 12 < current && subwave6 == false)
        {
            Instantiate(enemy, east.transform.position, Quaternion.identity);
            Instantiate(enemy, southeast.transform.position, Quaternion.identity);
            Instantiate(enemy, northeast.transform.position, Quaternion.identity);
            Instantiate(enemy, north.transform.position, Quaternion.identity);
            Instantiate(enemy, northwest.transform.position, Quaternion.identity);
            Instantiate(enemy, west.transform.position, Quaternion.identity);
            Instantiate(enemy, southwest.transform.position, Quaternion.identity);
            subwave6 = true;
        }
    }
}
