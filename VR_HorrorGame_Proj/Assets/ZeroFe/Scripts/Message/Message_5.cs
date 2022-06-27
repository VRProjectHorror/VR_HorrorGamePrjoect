using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 쪽지 ui를 종료하면 옆 방에서 농구공 튀기는 소리가 재생된다
public class Message_5 : Message
{
    public Transform nextRoomTr;
    public FlashController flash;

    protected override void Trigger()
    {
        flash.StopFlash();
        var sfx = nextRoomTr.GetComponent<AudioSource>();
        sfx.Play();
    }
}
