using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 6��° ����
public class Message_6 : Message
{
    public LockerOpen fittingRoomDoor;

    protected override void Trigger()
    {
        fittingRoomDoor.Close();
    }
}
