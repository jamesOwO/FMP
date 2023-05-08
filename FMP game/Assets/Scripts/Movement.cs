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

    [SerializeField] private LayerMask groundMask;
    private Camera mainCamera;



    void Start()
    {
        mainCamera = Camera.main;

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

        animator.SetBool("shadowForm", false);

        if (Input.GetKeyDown(KeyCode.Space))
            Dash();
    }

    private void Dash()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            animator.SetBool("shadowForm", true);
            this.transform.position = position;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }

}
