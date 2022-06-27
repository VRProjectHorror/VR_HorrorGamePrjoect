using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 자재 창고 방 앞 트리거
// 검은 형체 사라짐
public class Trigger_Warehouse_2 : MonoBehaviour
{
    private bool isTriggered = false;

    public LockerOpen fittingRoomDoorEntrance;
    public LockerOpen fittingRoomDoor;

    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered)
        {
            return;
        }
        isTriggered = true;

        audioSource.Stop();

        fittingRoomDoor.Open(0.5f);
        fittingRoomDoorEntrance.Open(0.5f);
    }
}
