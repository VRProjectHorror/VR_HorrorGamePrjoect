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

        print("��۽� ��");
        isPlayed = true;
        door.Close();
    }
}
