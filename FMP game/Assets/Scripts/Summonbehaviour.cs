using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summonbehaviour : MonoBehaviour
{
    [SerializeField] private Playercontroller Playercontroller;
    public int speed;
    GameObject target;
    public Animator animator;
    bool dieonce = true;
    float deathtimer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Enemy_bat");

        Vector3 localPosition = target.transform.position - transform.position;
        localPosition = localPosition.normalized; // The normalized direction in LOCAL space
        transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
        
        
        if (deathtimer + 0.8 < Time.time && dieonce == false)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy_bat")
        {
            animator.SetBool("deth", true);

            if (dieonce)
            {
                deathtimer = Time.time;
                dieonce = false;
            }
        }

    }
}
