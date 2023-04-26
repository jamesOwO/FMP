using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class Movement : MonoBehaviour
{
    public float horizontalMovement;
    public float verticalMovement;
    public float speed = 5.0f;

    public Animator animator;
    private BoxCollider coll;
    private Rigidbody rb;

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

        // Move the player
        rb.AddForce(movementDirection * speed, ForceMode.Force);


    }
}
