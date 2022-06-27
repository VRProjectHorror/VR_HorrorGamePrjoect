using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ui�� �����ϸ� �� �濡�� �󱸰� Ƣ��� �Ҹ��� ����ȴ�
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
