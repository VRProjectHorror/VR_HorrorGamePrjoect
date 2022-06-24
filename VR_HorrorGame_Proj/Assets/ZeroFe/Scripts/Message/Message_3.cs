using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_3 : Message
{
    // 검은 형체 활성화
    public GameObject black;

    // 음산한 음악 및 

    protected override void Trigger()
    {
        print("세 번째 쪽지 실행");
        black.SetActive(true);
    }
}
