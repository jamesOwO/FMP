using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Spawning : MonoBehaviour
{
    int numofenemies;
    List<GameObject> listOfOpponents = new List<GameObject>();

    public GameObject southeast, east, northeast, north, northwest, west, southwest;
    [SerializeField] private Playercontroller Playercontroller;

    double roundstart, round2start = 0, round3start = 0;
    double current;
    public GameObject enemy;
    bool wave1 = false, wave2 = false, wave3 = false, subwave1, subwave2, subwave3, subwave4;
    int wavecount = 0;
    
    void Start()
    {
        roundstart = Time.time;
    }

    void Update()
    {
        current = Time.time + roundstart;

        if (Input.GetKeyDown(KeyCode.Q))
            wavecount += 1;

        if (wavecount == 1 && wave1 == false)
        {
            round1();
        }
        if (wavecount == 2 && wave2 == false)
        {
            round2();
        }
        if (wavecount == 3 && wave3 == false)
        {
            round3();
        }

    }
    void round1()
    {
        Debug.Log("round 3 begin");

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
            subwave1 = false;subwave2 = false;subwave3 = false;
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
            subwave1 = false; subwave2 = false; subwave3 = false; subwave4 = false;
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
        if (round3start + 9 < current && subwave4 == false)
        {
            Instantiate(enemy, north.transform.position, Quaternion.identity);
            Instantiate(enemy, northeast.transform.position, Quaternion.identity);
            Instantiate(enemy, northwest.transform.position, Quaternion.identity);
            subwave4 = true;
        }

    }
}
