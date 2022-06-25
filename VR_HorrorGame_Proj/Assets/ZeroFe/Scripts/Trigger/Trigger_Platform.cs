using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Platform : MonoBehaviour
{
    public AudioClip microphoneFeedbackSound;
    public AudioClip spotLightOnSound;
    public Light platformSpotLight;

    private bool isPlayed = false;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 재실행 막기
        if (isPlayed)
        {
            return;
        }

        print("플랫폼 올라옴");
        StartCoroutine(IETriggerSequence());
    }

    IEnumerator IETriggerSequence()
    {
        audioSource.loop = false;
        audioSource.PlayOneShot(microphoneFeedbackSound);

        // 마이크 소리 끝날 때까지 대기
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        audioSource.PlayOneShot(spotLightOnSound);
        platformSpotLight.enabled = true;
    }
}
