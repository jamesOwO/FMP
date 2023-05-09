using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

    public float ability1duration = 1.2f;
    public Animator animator;
    private BoxCollider coll;
    private Rigidbody rb;
    public GameObject floor;
    public GameObject ability1;
    
    
    Stopwatch stopwatch = new Stopwatch();
    public double ability1_duration = 1.3;
    public double ability1_cooldown = 3;
    double ability1_lastuse = 0;




    [SerializeField] private LayerMask groundMask;
    private Camera mainCamera;



    void Start()
    {
        stopwatch.Start();

        mainCamera = Camera.main;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        coll = GetComponent<BoxCollider>();
        
    }

    void Update()
    {


        horizontalMovement = Input.GetAxis("Horizontal");

        verticalMovement = Input.GetAxis("Vertical");

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

        Attack();
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


    private void Attack()
    {
        var (success, position) = GetMousePosition();

        if (Input.GetKeyDown(KeyCode.E) && success )
        {
            Instantiate(ability1, position, Quaternion.identity);
            ability1_lastuse = Convert.ToDouble(stopwatch.Elapsed) + ability1_cooldown;

        }
        if (Convert.ToDouble(stopwatch.Elapsed) > ability1_duration)
        {
            Destroy(ability1);
        }

    }


    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }

}
