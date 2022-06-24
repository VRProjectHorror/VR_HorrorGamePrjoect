using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTrigger : MonoBehaviour
{
    public GameObject playerFollower;
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            playerFollower.SetActive(true);
        }
    }
}
