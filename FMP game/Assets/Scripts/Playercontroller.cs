using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Playercontroller : MonoBehaviour
{
    public float horizontalMovement;
    public float verticalMovement;
    public float speed = 0.1f;
    public float dashspeed = 1f;

    public GameObject weapon;
    public GameObject auto;

    public float ability1duration = 1.2f;
    public Animator hearts;
    public Animator animator;
    private BoxCollider coll;
    private Rigidbody rb;
    public GameObject floor;
    public GameObject ability1;

    [SerializeField] public int health {get; private set;} = 5;
    
    public double ability1_duration = 1.3;
    public double ability1_cooldown = 3;
    double ability1_next;
    double auto_next;

    [SerializeField] private LayerMask groundMask;
    private Camera mainCamera;

    float damage_cooldown;
    void Start()
    {
        mainCamera = Camera.main;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        coll = GetComponent<BoxCollider>();
    }

    void Update()
    {
        hearts.SetInteger("harts", health);
        var (success, position) = GetMousePosition();

        if (health > 0)
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
        else if (health < 1)
        {
            animator.SetBool("Died", true);
        }
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

        if (Input.GetKeyDown(KeyCode.E) && success && Time.time > ability1_next)
        {
            Instantiate(ability1, position, Quaternion.identity);
            ability1_next = Time.time + 3;
        }
        if (Input.GetMouseButton(0) && success && Time.time > auto_next)
        {
            Instantiate(auto, weapon.transform.position, Quaternion.identity);
            auto_next = Time.time + 0.2;

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
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy_bat")
        {
            if (damage_cooldown < Time.time)
            {
                health -= 1;
                damage_cooldown = Time.time + 1;
            }

        }
    }
}

