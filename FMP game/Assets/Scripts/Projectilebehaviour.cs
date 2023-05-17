using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectilebehaviour : MonoBehaviour
{
    Stopwatch stopwatch = new Stopwatch();
    double d = 1.3;
    TimeSpan t;

    [SerializeField] private LayerMask groundMask;
    public Camera mainCamera;
    private Rigidbody rb;
    Vector3 rotation;
    public float speed;
    [SerializeField] public GameObject weapon;
    private Quaternion _lookRotation;
    private Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        stopwatch.Start();
        t = TimeSpan.FromSeconds(d);

        mainCamera = Camera.main;

        var (success, position) = GetMousePosition();
        _direction = (position - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, 2f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.forward * speed;
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy_bat")
        {
            UnityEngine.Debug.Log("o");
            Destroy(this.gameObject);
        }

    }

}
