using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Exit : MonoBehaviour
{
    public Door_Sliding exitDoor;

    public bool triggable = false;
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!triggable && isTriggered)
        {
            return;
        }
        isTriggered = true;

        exitDoor.Open();
    }
}
