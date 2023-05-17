using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Destroyafteranimation : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    Stopwatch stopwatch = new Stopwatch();
    double d = 1.3;
    TimeSpan t;

    void Start()
    {
        stopwatch.Start();
        t = TimeSpan.FromSeconds(d);
    }
    void Update()
    { 
        if (stopwatch.Elapsed > t)
        {
            Destroy(gameObject);
        }
        
    }
}
