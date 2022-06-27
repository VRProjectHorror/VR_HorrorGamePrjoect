using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� â�� �� �� Ʈ����
// ���� ��ü �����
public class Trigger_Warehouse_2 : MonoBehaviour
{
    private bool isTriggered = false;

    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered)
        {
            return;
        }
        isTriggered = true;

        audioSource.Stop();
    }
}
