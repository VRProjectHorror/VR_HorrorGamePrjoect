using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private AudioClip turnOnSound;
    [SerializeField] private AudioClip turnOffSound;

    private AudioSource audioSource;
    private Light _light;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        _light = GetComponent<Light>();
    }

    public void TurnOn()
    {
        _light.enabled = true;
        audioSource.PlayOneShot(turnOnSound);
    }

    public void TurnOff()
    {
        _light.enabled = false;
        audioSource.PlayOneShot(turnOffSound);
    }
}
