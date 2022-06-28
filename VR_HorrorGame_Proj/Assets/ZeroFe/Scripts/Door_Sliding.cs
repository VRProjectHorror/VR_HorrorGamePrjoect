using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 미는 형식의 문
public class Door_Sliding : MonoBehaviour
{
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform rightDoor;
    [SerializeField] private float openSize = 1.0f;
    [SerializeField] private float openTime = 0.5f;

    private Vector3 leftSize;
    private Vector3 rightSize;

    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        rightSize = openSize * Vector3.right;
        leftSize = -rightSize;
    }

    public void Open()
    {
        StartCoroutine(IEOpenAnim());
    }

    IEnumerator IEOpenAnim()
    {
        audioSource.PlayOneShot(openSound);

        for (float t = 0.0f; t < openTime; t += Time.deltaTime)
        {
            leftDoor.localPosition = Vector3.Lerp(Vector3.zero, leftSize, t / openTime);
            rightDoor.localPosition = Vector3.Lerp(Vector3.zero, rightSize, t / openTime);
            yield return 0;
        }

        leftDoor.localPosition = leftSize;
        rightDoor.localPosition = rightSize;
    }

    public void Close()
    {
        StartCoroutine(IECloseAnim());
    }

    IEnumerator IECloseAnim()
    {
        audioSource.PlayOneShot(closeSound);

        for (float t = 0.0f; t < openTime; t += Time.deltaTime)
        {
            leftDoor.localPosition = Vector3.Lerp(Vector3.zero, leftSize, t / openTime);
            rightDoor.localPosition = Vector3.Lerp(Vector3.zero, rightSize, t / openTime);
            yield return 0;
        }

        leftDoor.localPosition = leftSize;
        rightDoor.localPosition = rightSize;
    }
}
