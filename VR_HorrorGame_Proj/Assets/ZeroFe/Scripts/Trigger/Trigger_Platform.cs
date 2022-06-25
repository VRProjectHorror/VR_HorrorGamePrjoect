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
        // ����� ����
        if (isPlayed)
        {
            return;
        }

        print("�÷��� �ö��");
        StartCoroutine(IETriggerSequence());
    }

    IEnumerator IETriggerSequence()
    {
        audioSource.loop = false;
        audioSource.PlayOneShot(microphoneFeedbackSound);

        // ����ũ �Ҹ� ���� ������ ���
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        audioSource.PlayOneShot(spotLightOnSound);
        platformSpotLight.enabled = true;
    }
}
