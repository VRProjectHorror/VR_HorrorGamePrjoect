using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_4 : Message
{
    // 글리치
    // 문 열림
    public LockerOpen waitRoomDoor;

    protected override void Trigger()
    {
        // 글리치 연출

        waitRoomDoor.Open(0.5f);
    }
}
