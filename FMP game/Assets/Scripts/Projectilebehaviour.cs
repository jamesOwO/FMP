using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectilebehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    public Camera mainCamera;
    private Rigidbody rb;
    Vector3 rotation;
    public float speed = 1;
    [SerializeField] public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        var (success, position) = GetMousePosition(); 
        Vector3 direction = position - transform.position;
        Vector3 rotation = transform.position - position;
    }

    // Update is called once per frame
    void Update()
    {
        var (success, position) = GetMousePosition();

        //transform.Rotate(rotation);
        transform.position += Vector3.MoveTowards(weapon.transform.position, position, speed);
        Debug.Log(position);
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
