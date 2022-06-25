using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// ���� �˾� ���� Ŭ����
/// </summary>
public class PopupSystem : MonoBehaviour
{
    public static PopupSystem Instance { get; private set; }

    [SerializeField] private GameObject popup;
    [SerializeField] private TextMeshProUGUI messageText;

    [Header("OpenPopup Animation")] 
    [SerializeField, Tooltip("���� ���� / �ݱ� �ִϸ��̼� �ð�")]
    private float animationTime = 0.5f;
    [SerializeField, Tooltip("���� �� �� ���ƿ��� ����� ��ġ")] 
    private float translateRelativeStartPosY = -100;
    // ���� UI �ʱ� ��ġ ����
    private Vector3 popupInitLocalPosition;

    [SerializeField, Tooltip("���� �� �� �Ҹ�")] 
    private AudioClip messageOpenSound;
    [SerializeField, Tooltip("���� ġ�� �� �Ҹ�")]
    private AudioClip messageCloseSound;

    // ���� UI �����ְ� �ִ��� �����ϴ� ����
    // popup.activeSelf�� popup �ִϸ��̼� ���� �� EndPopup�� �ߺ� ������� ���ϴ� ������ �ִ�
    public bool IsShowingPopup { get; private set; } = false;

    private AudioSource audioSource;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();

        canvasGroup = popup.GetComponent<CanvasGroup>();
        popupInitLocalPosition = transform.localPosition;
    }

    public void OpenPopup(string context)
    {
        messageText.text = context;
        IsShowingPopup = true;
        StartCoroutine(IEFadeIn());
    }

    IEnumerator IEFadeIn()
    {
        // �ʱ� ����
        popup.SetActive(true);
        Vector3 popupAnimStartPos = popupInitLocalPosition + Vector3.up * translateRelativeStartPosY;
        popup.transform.localPosition = popupAnimStartPos;
        canvasGroup.alpha = 0;

        audioSource.PlayOneShot(messageOpenSound);

        for (float t = 0; t < animationTime; t += Time.deltaTime)
        {
            // ���� ���� �� �ٸ� ������� �ִϸ��̼� �����ϰ� �ʹٸ� ratio ���ĸ� �����ϸ� ��
            // ��, ratio�� 0 ~ 1 ���� ���� ���� �Ѵ�
            float ratio = t / animationTime;

            popup.transform.localPosition = Vector3.Lerp(popupAnimStartPos, popupInitLocalPosition, ratio);
            canvasGroup.alpha = ratio;
            yield return 0;
        }

        canvasGroup.alpha = 1;
        popup.transform.localPosition = popupInitLocalPosition;
    }

    public void ClosePopup(Action trigger)
    {
        IsShowingPopup = false;
        StartCoroutine(IEFadeOut(trigger));
    }

    IEnumerator IEFadeOut(Action trigger)
    {
        Vector3 popupAnimEndPos = popupInitLocalPosition + Vector3.up * translateRelativeStartPosY;
        popup.transform.localPosition = popupInitLocalPosition;
        canvasGroup.alpha = 1;

        audioSource.PlayOneShot(messageCloseSound);

        for (float t = 0; t < animationTime; t += Time.deltaTime)
        {
            // ���� ���� �� �ٸ� ������� �ִϸ��̼� �����ϰ� �ʹٸ� ratio ���ĸ� �����ϸ� ��
            // ��, ratio�� 0 ~ 1 ���� ���� ���� �Ѵ�
            float ratio = t / animationTime;

            popup.transform.localPosition = Vector3.Lerp(popupAnimEndPos, popupInitLocalPosition, 1 - ratio);
            canvasGroup.alpha = 1 - ratio;
            yield return 0;
        }

        canvasGroup.alpha = 0;
        popup.transform.localPosition = popupInitLocalPosition;
        popup.SetActive(false);
        trigger?.Invoke();
    }
}
