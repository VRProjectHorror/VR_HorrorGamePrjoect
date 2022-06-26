using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 메모 내용을 관리, 저장하는 클래스
/// 추가적인 행동 내용은 함수 내용 정의해서 사용할 것
/// </summary>
public abstract class Message : MonoBehaviour
{
    [TextArea(3, 3), Tooltip("쪽지 안에 들어갈 내용")]
    public string context;

    // 쪽지 애니메이션 실행 및 팝업으로 띄우기
    public void OpenMessage()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        PopupSystem.Instance.OpenPopup(context);
    }

    // 팝업 닫기
    public void CloseMessage()
    {
        PopupSystem.Instance.ClosePopup(Trigger);
        MessageManager.Instance.ActiveCurrentMessage();
    }

    protected abstract void Trigger();
}
