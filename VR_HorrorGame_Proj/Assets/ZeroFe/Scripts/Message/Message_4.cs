using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_4 : Message
{
    // �۸�ġ
    // �� ����
    public LockerOpen waitRoomDoor;
    public GameObject blackSilhouette;
    protected override void Trigger()
    {
        // �۸�ġ ����

        waitRoomDoor.Open(0.5f);
        blackSilhouette.SetActive(true);
    }
}
