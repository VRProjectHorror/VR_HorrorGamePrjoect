using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public static BGMPlayer Instance { get; private set; }

    [SerializeField] private AudioClip mainBGM;
    private float currTime;
    [SerializeField] private float fadeTime = 3.0f;
    [SerializeField] private float volumeSize = 1.0f;

    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayBGM();
    }

    // 게임 시작하고 원할 때부터 BGM 플레이
    public void PlayBGM()
    {
        audioSource.clip = mainBGM;
        audioSource.Play();
    }

    // 기존에 플레이하던 음악을 바꿔서 재생
    // 바꾸는 동안 각 음악이 Fade In / Fade Out
    public void Change(AudioClip newBGM)
    {
        StartCoroutine(IEChange(newBGM));
    }

    IEnumerator IEChange(AudioClip newBGM)
    {
        yield return IESoundFadeOut();
        currTime = audioSource.time;
        audioSource.Stop();
        audioSource.time = 0;
        audioSource.clip = newBGM;
        audioSource.Play();
        yield return IESoundFadeIn();
    }

    // 이전에 플레이하던 음악으로 바꾸기
    public void Rollback()
    {
        StartCoroutine(IERollback());
    }

    IEnumerator IERollback()
    {
        yield return IESoundFadeOut();
        audioSource.clip = mainBGM;
        audioSource.Play();
        audioSource.time = currTime;
        yield return IESoundFadeIn();
    }

    IEnumerator IESoundFadeIn()
    {
        for (float t = 0.0f; t < fadeTime; t += Time.deltaTime)
        {
            audioSource.volume = volumeSize * t / fadeTime;
            yield return 0;
        }
        audioSource.volume = volumeSize;
    }

    IEnumerator IESoundFadeOut()
    {
        for (float t = 0.0f; t < fadeTime; t += Time.deltaTime)
        {
            audioSource.volume = volumeSize * (1 - t / fadeTime);
            yield return 0;
        }
        audioSource.volume = 0.0f;
    }
}
