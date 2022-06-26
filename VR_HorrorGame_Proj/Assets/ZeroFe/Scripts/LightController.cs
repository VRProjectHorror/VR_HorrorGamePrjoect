using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private AudioClip turnOnSound;
    [SerializeField] private AudioClip turnOffSound;

    private AudioSource audioSource;
    private Light light;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        light = GetComponent<Light>();
    }

    public void TurnOn()
    {
        light.enabled = true;
        audioSource.PlayOneShot(turnOnSound);
    }

    public void TurnOff()
    {
        light.enabled = false;
        audioSource.PlayOneShot(turnOffSound);
    }
}
