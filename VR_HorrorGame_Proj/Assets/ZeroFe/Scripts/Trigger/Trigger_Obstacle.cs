using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Obstacle : MonoBehaviour
{
    public Rigidbody obstacle;
    public float power = 1.5f;
    public AudioClip impactSound;
    public float impactSoundWaitTime = 0.3f;
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            obstacle.useGravity = true;
            obstacle.isKinematic = false;
            obstacle.AddTorque(obstacle.transform.up * power, ForceMode.Impulse);

            Invoke(nameof(PlaySound), impactSoundWaitTime);
        }
    }

    private void PlaySound()
    {
        SFXPlayer.Instance.PlaySpatialSound(obstacle.transform.position, impactSound);
    }
}
