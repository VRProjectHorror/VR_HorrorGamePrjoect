using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ui�� �����ϸ� �� �濡�� �󱸰� Ƣ��� �Ҹ��� ����ȴ�
public class Message_5 : Message
{
    public Transform nextRoomTr;
    public FlashController flash;
    public FlashController flash2;

    protected override void Trigger()
    {
        Player_Glitch.instance.SetGlitch(0.5f);
        flash.StopFlash();
        var sfx = nextRoomTr.GetComponent<AudioSource>();
        sfx.Play();
        flash2.StartFlash();
    }
}
