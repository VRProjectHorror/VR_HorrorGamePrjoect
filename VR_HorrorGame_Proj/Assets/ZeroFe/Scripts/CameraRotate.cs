using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField, Range(100, 1000)] 
    private float rotationSpeed = 350.0f;
    private float rx = 0.0f;
    private float ry = 0.0f;

    private float bottomClamp = -90.0f;
    private float topClamp = 90.0f;

    private Camera _main;

    private void Awake()
    {
        _main = Camera.main;
    }

    private void Start()
    {
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        
        ry += mx * Time.deltaTime * rotationSpeed;
        rx -= my * Time.deltaTime * rotationSpeed;
        rx = Mathf.Clamp(rx, bottomClamp, topClamp);

        transform.eulerAngles = new Vector3(rx, ry, 0);
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
