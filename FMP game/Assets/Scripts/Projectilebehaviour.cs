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
    private Quaternion _lookRotation;
    private Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        var (success, position) = GetMousePosition();
        _direction = (position - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.position += transform.forward * 0.5f;
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
}
