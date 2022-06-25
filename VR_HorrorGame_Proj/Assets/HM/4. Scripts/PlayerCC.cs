using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCC : MonoBehaviour
{
    CharacterController cc;

    private float gravity = -9.81f;
    private float yVelocity = 0.0f;

    public float movespeed;
    public GameObject forward;

    // Start is called before the first frame update
    void Start()
    {
        cc = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        SetGravity();

       
    }

    void PlayerMove()
    {
        Vector2 Lpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        Vector2 Rpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);

        Vector3 dir = transform.forward;
        dir.y = 0;
        dir = dir.normalized;
        /* 
        transform.forward가 y축에 수직이라면 따로 normalize할 필요 없음
        이 경우 
        Vector3 dir = transform.forward;
        만 있어도 됨
        */

        // yVelocity는 중력 따로 계산하고 있다 가정
        Vector3 totalVelocity = dir * movespeed * Rpos.y + Vector3.up * yVelocity;

        // 이동 적용
        cc.Move(totalVelocity * Time.deltaTime);


        //this.transform.forward = forward.transform.forward;

        //cc.Move((this.transform.forward * Rpos.y * Time.deltaTime * 2f));

        this.transform.Rotate(this.transform.up * Lpos.x * Time.deltaTime * 50f);
    }

    void SetGravity()
    {
        if (cc.isGrounded)
        {
            yVelocity = 0;
        }

        yVelocity += gravity * Time.deltaTime;
    }
}
//thumbstick 제어 Axis1d : vector 1(x)  axis2d : vector2(y)
//Vector2 Lpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
//this.transform.Translate(this.transform.forward * Lpos.y * Time.deltaTime * 1f);
//this.transform.Rotate(this.transform.up * Lpos.x * Time.deltaTime * 40f);