using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    public GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

    }
    void Update()
    {
        Vector3 localPosition = target.transform.position - transform.position;
        localPosition = localPosition.normalized; // The normalized direction in LOCAL space
        transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
    }
}
