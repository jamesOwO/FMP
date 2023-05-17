using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBehaviour : MonoBehaviour
{
    int enemyhealth = 5;
    [SerializeField] private Playercontroller Playercontroller;
    public int speed;
    GameObject target;
    public Animator animator;
    bool dieonce = true;
    float deathtimer;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Playercontroller.health > 0 && enemyhealth > 0)
        {
            Vector3 localPosition = target.transform.position - transform.position;
            localPosition = localPosition.normalized; // The normalized direction in LOCAL space
            transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
        }
        if (enemyhealth < 1)
        {
            animator.SetBool("Died", true);
            if (dieonce)
            {
                deathtimer = Time.time;
                dieonce = false;
            }
        }
        if (deathtimer > Time.time + 1)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            enemyhealth -= 1;
        }
    }
}
