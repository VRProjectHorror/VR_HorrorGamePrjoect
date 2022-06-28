using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowerAnimatorHandler : MonoBehaviour
{
    public AudioSource audioSource;

    public void WalkSound()
    {
        audioSource.Play();
    }
}
