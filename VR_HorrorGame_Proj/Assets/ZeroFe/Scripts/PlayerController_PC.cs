using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

/// <summary>
/// 플레이어 조작을 관리하는 클래스
/// 팝업 등 상호작용에서 사용하는 조작도 같이 관리한다
/// (조작이 나뉘어 있으면 관리하기 까다롭고 키 입력 수정이 힘들기 때문)
/// </summary>
public class PlayerController_PC : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    private float gravity = -9.81f;
    private float yVelocity = 0.0f;

    [SerializeField] private GameObject messageIndicator;
    private GameObject messageObj;

    private bool isShowingPopup = false;


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
        if (!isShowingPopup) Move();
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
            ViewMessage();
        }

        RaycastHit hit;
        int playerLayer = 1 << LayerMask.NameToLayer("Player");
        if (Physics.Raycast(_main.transform.position, _main.transform.forward, out hit, 5, ~playerLayer))
        {
            if (hit.collider.CompareTag("Message"))
            {
                messageIndicator.SetActive(true);
                messageObj = hit.collider.gameObject;
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
