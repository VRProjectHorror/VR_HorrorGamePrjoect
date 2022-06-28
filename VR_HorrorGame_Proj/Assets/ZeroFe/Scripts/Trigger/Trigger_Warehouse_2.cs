using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� â�� �� �� Ʈ����
// ���� ��ü �����
public class Trigger_Warehouse_2 : MonoBehaviour
{
    private bool isTriggered = false;

    public FlashController warehouse2Flash;
    public FlashController fittingRoomFlash;

    public LockerOpen fittingRoomDoorEntrance;
    public LockerOpen fittingRoomDoor;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered)
        {
            return;
        }
        isTriggered = true;

        audioSource.Stop();

        warehouse2Flash.StopFlash();

        fittingRoomDoor.Open(0.5f);
        fittingRoomDoorEntrance.Open(0.5f);
        fittingRoomFlash.StartFlash();
    }
}
