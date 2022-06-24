using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public Rigidbody obstacle;
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            obstacle.useGravity = true;
            obstacle.isKinematic = false;
            obstacle.AddForce(obstacle.transform.right * 3, ForceMode.Impulse);
        }
    }
}
