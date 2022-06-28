using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCC : MonoBehaviour
{
    AudioSource playerSound;
    [SerializeField]
    AudioClip[] playersoundclip;

    CharacterController cc;
    [SerializeField]
    GameObject playerCam;

    private float gravity = -9.81f;
    private float yVelocity = 0.0f;

    public float movespeed;


    [SerializeField] private GameObject messageIndicator;
    [SerializeField]
    private GameObject messageObj;

    private bool isShowingPopup = false;


    // Start is called before the first frame update
    void Start()
    {
        cc = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowingPopup == false)
        {
            
            PlayerMove();
        }

        SetGravity();
        Interaction();
        //if (PlayerCellPhone.instance.isOnUI == false)
        //{

        //}
        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward);
    }

    void PlayerMove()
    {
        Vector2 Lpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        Vector2 Rpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

        Vector3 dir = transform.forward;
        dir.y = 0;
        dir = dir.normalized;

        Vector3 totalVelocity = dir * movespeed * Rpos.y + Vector3.up * yVelocity;

        cc.Move(totalVelocity * Time.deltaTime);

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

    void Interaction()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) && messageObj)
        {
            ViewMessage();
        }

        RaycastHit hit;

        int playerLayer = 1 << LayerMask.NameToLayer("Player");
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, 15, ~playerLayer))
        {


            if (hit.collider.CompareTag("Message"))
            {
                messageIndicator.SetActive(true);
                messageObj = hit.collider.gameObject;
                print("메세지오브젝트 확인");
            }
            else
            {
                messageIndicator.SetActive(false);
                if (!isShowingPopup)
                {
                    messageObj = null;
                }
            }
        }

    }

    private void ViewMessage()
    {
        // 쪽지 열 수 있으면 쪽지 열기
        if (!isShowingPopup)
        {
            var message = messageObj.GetComponent<Message>();
            messageIndicator.SetActive(false);
            isShowingPopup = true;
            message.OpenMessage();
        }
        // 쪽지 열고 있는 상태 - 닫기
        else
        {
            print("Close");
            var message = messageObj.GetComponent<Message>();
            message.CloseMessage();
            messageObj = null;
            isShowingPopup = false;
        }
    }
}
