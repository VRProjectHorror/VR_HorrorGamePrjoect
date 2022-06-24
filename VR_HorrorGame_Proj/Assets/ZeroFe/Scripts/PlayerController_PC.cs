using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_PC : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    private float gravity = -9.81f;
    private float yVelocity = 0.0f;

    [SerializeField] private GameObject messageIndicator;
    private GameObject messageObj;

    private bool movable = true;


    private CharacterController cc;
    private Camera _main;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        _main = Camera.main;
    }

    void Update()
    {
        ApplyGravity();
        if (movable) Move();
        Interaction();
    }

    private void ApplyGravity()
    {
        if (cc.isGrounded)
        {
            yVelocity = 0;
        }

        yVelocity += gravity * Time.deltaTime;
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = _main.transform.TransformDirection(dir);
        dir.y = 0;
        dir = dir.normalized;

        Vector3 totalVelocity = dir * moveSpeed + Vector3.up * yVelocity;

        cc.Move(totalVelocity * Time.deltaTime);
    }

    private void Interaction()
    {
        if (Input.GetButtonDown("Fire1") && messageObj)
        {
            var message = messageObj.GetComponent<Message>();
            messageIndicator.SetActive(false);
            messageObj = null;
            movable = false;
            message.EarnMessage(SetMovable);
        }

        RaycastHit hit;
        if (Physics.Raycast(_main.transform.position, _main.transform.forward, out hit, 5))
        {
            //if (hit.collider.CompareTag("Message"))
            //{
            //    messageIndicator.SetActive(true);
            //    messageObj = hit.collider.gameObject;
            //}
            //else
            //{
            //    messageIndicator.SetActive(false);
            //    messageObj = null;
            //}
        }
    }

    public void SetMovable()
    {
        movable = true;
    }
}
