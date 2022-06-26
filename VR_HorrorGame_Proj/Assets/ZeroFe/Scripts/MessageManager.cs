using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 쪽지가 순차적으로 나오게 관리하는 클래스
/// 테스트 편의를 위해 이 클래스에서 디버그 기능 지원
/// </summary>
public class MessageManager : MonoBehaviour
{
    public static MessageManager Instance { get; private set; }

    public GameObject[] messages;
    // 현재 선택된 쪽지 위치
    // 시작하자마자 ActiveCurrentMessage()를 호출해서 pos가 0이 되도록 만들기 위해 -1로 설정
    public int pos = -1;

    // 디버그용
    public GameObject player;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // For Debug
        if (!player)
        {
            player = GameObject.Find("Player");
        }

        // 나머지 쪽지는 다 비활성화
        foreach (var message in messages)
        {
            message.SetActive(false);
        }

        ActiveCurrentMessage();
    }

    private void Update()
    {
        // 디버그 기능 : 다음 쪽지 위치로 오기
        if (Input.GetKeyDown(KeyCode.O))
        {
            TestNextMessage();
        }
    }

    // 다음 쪽지 불러오기
    public void ActiveCurrentMessage()
    {
        // 다음 쪽지가 없는 경우 끝낸다
        if (pos >= messages.Length - 1)
        {
            return;
        }

        Debug.Assert(pos < messages.Length - 1, "Error : Next Message is Invalid");
        // 다음 쪽지 불러
        messages[++pos].SetActive(true);
    }

#if UNITY_EDITOR
    // 디버그 기능 : 플레이어를 현재 쪽지 위치로 이동
    public void TestNextMessage()
    {
        // 다음 쪽지 불러오기
        ActiveCurrentMessage();

        // 해당 쪽지 위치로 플레이어 위치 불러옴
        player.GetComponent<CharacterController>().enabled = false;
        // 쪽지 프리팹의 X축이 
        player.transform.position = messages[pos].transform.position - messages[pos].transform.right;
        player.GetComponent<CharacterController>().enabled = true;
    }
#endif
}
