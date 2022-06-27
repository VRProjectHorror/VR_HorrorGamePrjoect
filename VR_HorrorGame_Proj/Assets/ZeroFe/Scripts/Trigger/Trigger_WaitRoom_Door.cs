using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_WaitRoom_Door : MonoBehaviour
{
    public Wisp wisp;

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered)
        {
            return;
        }
        isTriggered = true;

        wisp.gameObject.SetActive(true);
    }
    
}
