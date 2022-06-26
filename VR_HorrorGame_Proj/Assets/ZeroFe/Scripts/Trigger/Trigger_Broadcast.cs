using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Broadcast : MonoBehaviour
{
    public LockerOpen door;

    private bool isPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isPlayed)
        {
            return;
        }

        print("방송실 들어감");
        isPlayed = true;
        door.Close();
    }
}
