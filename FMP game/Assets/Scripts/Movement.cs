using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float horizontalMovement;
    public float verticalMovement;
    public float speed = 0.1f;
    public float dashspeed = 1f;


    public Animator animator;
    private BoxCollider coll;
    private Rigidbody rb;
    public GameObject floor;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        coll = GetComponent<BoxCollider>();
        
    }

    void Update()
    {
        // This will detect forward and backward movement
        horizontalMovement = Input.GetAxis("Horizontal");

        // This will detect sideways movement
        verticalMovement = Input.GetAxis("Vertical");

        // Calculate the direction to move the player
        Vector3 movementDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        animator.SetFloat("Left/Right", verticalMovement);
        animator.SetFloat("Up/Down", horizontalMovement);
        if (horizontalMovement > 0 || horizontalMovement < 0)
        {
            animator.SetFloat("Speed", 1);
        }
        else if (verticalMovement > 0 || verticalMovement < 0)
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
        this.transform.position += movementDirection * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (floor.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                this.transform.position += hit.point * dashspeed;
            }


        }
    }
}
